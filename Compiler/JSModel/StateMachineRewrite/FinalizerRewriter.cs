using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Saltarelle.Compiler.JSModel.Expressions;
using Saltarelle.Compiler.JSModel.Statements;

namespace Saltarelle.Compiler.JSModel.StateMachineRewrite
{
	internal class FinalizerRewriter : RewriterVisitorBase<object>, IStateMachineRewriterIntermediateStatementsVisitor<JsStatement, object> {
		private string _stateVariableName;
		private Dictionary<string, State> _labelStates = new Dictionary<string, State>();

		public FinalizerRewriter(string stateVariableName, Dictionary<string, State> labelStates) {
			_stateVariableName = stateVariableName;
			_labelStates = labelStates;
		}

		public JsBlockStatement Process(JsBlockStatement statement) {
			return (JsBlockStatement)VisitStatement(statement, null);
		}

		public override JsStatement VisitGotoStatement(JsGotoStatement statement, object data) {
			throw new InvalidOperationException("Shouldn't happen");
		}

		public override JsStatement VisitFunctionStatement(JsFunctionStatement statement, object data) {
			return statement;
		}

		public override JsExpression VisitFunctionDefinitionExpression(JsFunctionDefinitionExpression expression, object data) {
			return expression;
		}

		public override JsSwitchSection VisitSwitchSection(JsSwitchSection clause, object data) {
			return base.VisitSwitchSection(clause, data);
		}

		public override IList<JsStatement> VisitStatements(IList<JsStatement> statements, object data) {
			return VisitCollection(statements, (s, i) => {
				if (s is JsSetNextStateStatement && i < statements.Count - 1) {
					var next = statements[i + 1];
					if (next is JsBlockStatement && ((JsBlockStatement)next).Statements.Count > 0)
						next = ((JsBlockStatement)next).Statements[0];
					if (next is JsSetNextStateStatement || next is JsGotoStateStatement)
						return ImmutableList<JsStatement>.Empty;	// The current statement is directly overridden by the next one - ignore it.
				}

				var after = VisitStatement(s, data);
				var afterBlock = after as JsBlockStatement;
				if (afterBlock != null && afterBlock.MergeWithParent)
					return afterBlock.Statements;
				else
					return new[] { after };
			});
		}

		public JsStatement VisitGotoStateStatement(JsGotoStateStatement statement, object data) {
			var result = new List<JsStatement>();
			State targetState;
			if (statement.TargetState == null) {
				if (!_labelStates.TryGetValue(statement.TargetLabel, out targetState))
					throw new InvalidOperationException("The label " + statement.TargetLabel + " does not exist.");
			}
			else
				targetState = statement.TargetState.Value;

			var remaining = statement.CurrentState.FinallyStack;
			JsStatement finallyExecutionStatement = null;
			for (int i = 0, n = remaining.Count() - targetState.FinallyStack.Count(); i < n; i++) {
				var current = remaining.Peek();
				remaining = remaining.Pop();
				var block = JsStatement.BlockMerged(
						JsExpression.Assign(JsExpression.Identifier(_stateVariableName), JsExpression.Number(remaining.IsEmpty ? -1 : remaining.Peek().Item1)),
						JsExpression.Invocation(JsExpression.Member(JsExpression.Identifier(current.Item2), "call"), JsExpression.This)
				);

				if (finallyExecutionStatement == null) {
					finallyExecutionStatement = block;
				}
				else {
					finallyExecutionStatement = JsStatement.Try(finallyExecutionStatement, null, block);
				}
			}

			if (finallyExecutionStatement != null)
				result.Add(finallyExecutionStatement);

			result.Add(MakeSetNextStateStatement(targetState.StateValue));
			result.Add(targetState.StateValue == -1 ? (JsStatement)JsStatement.Break(targetState.LoopLabelName) : JsStatement.Continue(targetState.LoopLabelName));
			return JsStatement.BlockMerged(result);
		}

		public JsStatement VisitSetNextStateStatement(JsSetNextStateStatement stmt, object data) {
			return MakeSetNextStateStatement(stmt.TargetStateValue);
		}

		private JsStatement MakeSetNextStateStatement(int targetStateValue) {
			return JsExpression.Assign(JsExpression.Identifier(_stateVariableName), JsExpression.Number(targetStateValue));
		}
	}
}