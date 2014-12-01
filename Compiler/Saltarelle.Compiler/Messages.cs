﻿using System;
using Microsoft.CodeAnalysis;

namespace Saltarelle.Compiler {
	using Message = Tuple<int, DiagnosticSeverity, string>;
	public static class Messages {
		public static readonly Message _7500 = Tuple.Create(7500, DiagnosticSeverity.Error, "Cannot use the type {0} in the inheritance list for type {1} because it is marked as not usable from script.");
		public static readonly Message _7501 = Tuple.Create(7501, DiagnosticSeverity.Error, "More than one unnamed constructor for the type {0}.");
		public static readonly Message _7505 = Tuple.Create(7505, DiagnosticSeverity.Error, "This constructor cannot be used from script.");
		public static readonly Message _7506 = Tuple.Create(7506, DiagnosticSeverity.Error, "Property {0}, declared as being a native indexer, is not an indexer with exactly one argument.");
		public static readonly Message _7507 = Tuple.Create(7507, DiagnosticSeverity.Error, "Cannot use the property {0} from script.");
		public static readonly Message _7508 = Tuple.Create(7508, DiagnosticSeverity.Error, "The field {0} is constant in script and cannot be assigned to.");
		public static readonly Message _7509 = Tuple.Create(7509, DiagnosticSeverity.Error, "The field {0} is not usable from script.");
		public static readonly Message _7511 = Tuple.Create(7511, DiagnosticSeverity.Error, "The event {0} is not usable from script.");
		public static readonly Message _7512 = Tuple.Create(7512, DiagnosticSeverity.Error, "The property {0} is not usable from script.");
		public static readonly Message _7513 = Tuple.Create(7513, DiagnosticSeverity.Error, "Only locals can be passed by reference.");
		public static readonly Message _7515 = Tuple.Create(7515, DiagnosticSeverity.Error, "Cannot use the type {0} in as a generic argument to the method {1} because it is marked as not usable from script.");
		public static readonly Message _7516 = Tuple.Create(7516, DiagnosticSeverity.Error, "The method {0} cannot be used from script.");
		public static readonly Message _7517 = Tuple.Create(7517, DiagnosticSeverity.Error, "Cannot use the the property {0} in an anonymous object initializer.");
		public static readonly Message _7518 = Tuple.Create(7518, DiagnosticSeverity.Error, "Cannot use the field {0} in an anonymous object initializer.");
		public static readonly Message _7519 = Tuple.Create(7519, DiagnosticSeverity.Error, "Cannot create an instance of the type {0} because it is marked as not usable from script.");
		public static readonly Message _7520 = Tuple.Create(7520, DiagnosticSeverity.Error, "Cannot use the type {0} in as a type argument for the class {1} because it is marked as not usable from script.");
		public static readonly Message _7522 = Tuple.Create(7522, DiagnosticSeverity.Error, "Cannot use the type {0} in an expression because it is marked as not usable from script.");
		public static readonly Message _7523 = Tuple.Create(7523, DiagnosticSeverity.Error, "Cannot perform method group conversion on {0} because {1}.");
		public static readonly Message _7524 = Tuple.Create(7524, DiagnosticSeverity.Error, "Cannot convert the method '{0}' to the delegate type '{1}' because the method and delegate type differ in whether they expand their param array.");
		public static readonly Message _7525 = Tuple.Create(7525, DiagnosticSeverity.Error, "Error in inline code compilation: {0}.");
		public static readonly Message _7526 = Tuple.Create(7526, DiagnosticSeverity.Error, "Dynamic invocations cannot use named arguments.");
		public static readonly Message _7527 = Tuple.Create(7527, DiagnosticSeverity.Error, "The member {0} cannot be initialized in an initializer statement because it was also initialized by the constructor call.");
		public static readonly Message _7528 = Tuple.Create(7528, DiagnosticSeverity.Error, "Dynamic indexing must have exactly one argument.");
		public static readonly Message _7529 = Tuple.Create(7529, DiagnosticSeverity.Error, "Cannot compile this dynamic invocation because all the applicable methods do not have the same script name. If you want to call the method with this exact name, cast the invocation target to dynamic.");
		public static readonly Message _7530 = Tuple.Create(7530, DiagnosticSeverity.Error, "Cannot compile this dynamic invocation because at least one of the applicable methods is not a normal method. If you want to call the method with this exact name, cast the invocation target to dynamic.");
		public static readonly Message _7531 = Tuple.Create(7531, DiagnosticSeverity.Error, "Cannot compile this dynamic invocation because the applicable methods are compiled in different ways.");
		public static readonly Message _7532 = Tuple.Create(7532, DiagnosticSeverity.Error, "Cannot compile this dynamic invocation because the applicable indexers differ in how they are compiled.");
		public static readonly Message _7533 = Tuple.Create(7533, DiagnosticSeverity.Error, "Cannot convert the delegate type {0} to {1} because they differ in whether the Javascript 'this' is bound to the first parameter.");
		public static readonly Message _7535 = Tuple.Create(7535, DiagnosticSeverity.Error, "The OnCompleted method used by an 'await' statement must be implemented as a normal method in script.");
		public static readonly Message _7536 = Tuple.Create(7536, DiagnosticSeverity.Error, "The type parameter {0} is not available for use in script. You must specify [IncludeGenericArguments] on the {1} {2} and/or any method it overrides or implements.");
		public static readonly Message _7537 = Tuple.Create(7537, DiagnosticSeverity.Error, "Cannot convert the delegate type {0} to {1} because they differ in whether the param array is expanded.");
		public static readonly Message _7538 = Tuple.Create(7538, DiagnosticSeverity.Error, "Cannot assign to `this' in non-constructor methods of immutable value types.");
		public static readonly Message _7539 = Tuple.Create(7539, DiagnosticSeverity.Error, "The mutable value type {0} cannot be used as a type argument.");
		public static readonly Message _7540 = Tuple.Create(7540, DiagnosticSeverity.Error, "Bitwise operations are not allowed on 64-bit types.");
		public static readonly Message _7541 = Tuple.Create(7541, DiagnosticSeverity.Error, "An expression of type `dynamic' cannot be awaited. To remove this error, insert a cast to the appropriate type.");
		public static readonly Message _7542 = Tuple.Create(7542, DiagnosticSeverity.Error, "An expression of type `dynamic' cannot be enumerated with foreach. To remove this error, insert a cast to the appropriate type.");
		public static readonly Message _7543 = Tuple.Create(7543, DiagnosticSeverity.Error, "Numeric case labels must be between -9007199254740992 and 9007199254740992");

		public static readonly Message _7800 = Tuple.Create(7800, DiagnosticSeverity.Error, "The program entry point {0} may not have any parameters.");
		public static readonly Message _7801 = Tuple.Create(7801, DiagnosticSeverity.Error, "The program entry point {0} must be implemented as a normal method.");
		public static readonly Message _7802 = Tuple.Create(7802, DiagnosticSeverity.Error, "Cyclic initialization required of the types {0}.");

		public static readonly Message _7950 = Tuple.Create(7950, DiagnosticSeverity.Error, "Error writing assembly: {0}.");
		public static readonly Message _7951 = Tuple.Create(7951, DiagnosticSeverity.Error, "Error writing script: {0}.");

		public static readonly Message _7994 = Tuple.Create(7994, DiagnosticSeverity.Error, "Failed to load plugin assembly `{0}': {1}.");
		public static readonly Message _7995 = Tuple.Create(7995, DiagnosticSeverity.Error, "Invalid script metadata for symbol `{0}' in referenced assembly `{1}'.");
		public static readonly Message _7996 = Tuple.Create(7996, DiagnosticSeverity.Error, "Indirectly referenced assembly `{0}' must be referenced.");
		public static readonly Message _7997 = Tuple.Create(7997, DiagnosticSeverity.Error, "Unable to resolve the assembly reference {0}.");
		public static readonly Message _7998 = Tuple.Create(7998, DiagnosticSeverity.Error, "Use of unsupported feature {0}.");

		public static readonly Message InternalError = Tuple.Create(7999, DiagnosticSeverity.Error, "INTERNAL ERROR: {0}. Please report this as an issue on https://github.com/erik-kallen/SaltarelleCompiler/");
	}
}
