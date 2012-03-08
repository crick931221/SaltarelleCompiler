﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Saltarelle.Compiler.Tests.MethodCompilationTests.StatementTests {
	[TestFixture]
	public class ThrowStatementTests : StatementTestBase {
		[Test]
		public void ThrowStatementThatDoesNotRequireAdditionalStatementsWorks() {
			AssertCorrect(
@"public void M() {
	System.Exception ex = null;
	// BEGIN
	throw ex;
	// END
}",
@"	throw $ex;
");
		}

		[Test]
		public void ThrowStatementThatRequiresAdditionalStatementsWorks() {
			AssertCorrect(
@"Exception MyProperty { get; set; }
public void M() {
	Exception ex = null;
	// BEGIN
	throw (MyProperty = ex);
	// END
}",
@"	this.set_MyProperty($ex);
	throw $ex;
");
		}

		[Test]
		public void RethrowStatementWorksThatDoesNotRequireAdditionalStatementsWorks() {
			AssertCorrect(
@"public void M() {
	// BEGIN
	try {
		try {
			try {
			}
			catch (System.Exception) {
				if (true) {
					throw;
				}
			}
		}
		catch (System.ArgumentException) {
			throw;
		}
	}
	catch {
		try {
		}
		catch {
			throw;
		}
		throw;
	}
	// END
}",
@"	try {
		try {
			try {
			}
			catch ($tmp1) {
				if (true) {
					throw $tmp1;
				}
			}
		}
		catch ($tmp2) {
			if ($TypeIs($tmp2, {ArgumentException})) {
				throw $tmp2;
			}
			else {
				throw $tmp2;
			}
		}
	}
	catch ($tmp3) {
		try {
		}
		catch ($tmp4) {
			throw $tmp4;
		}
		throw $tmp3;
	}
");
		}
	}
}
