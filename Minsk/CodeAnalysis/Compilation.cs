using System;
using System.Linq;
using System.Collections.Generic;
using Minsk.CodeAnalysis.Binding;
using Minsk.CodeAnalysis.Syntax;

namespace Minsk.CodeAnalysis
{
    public class Compilation {
        public SyntaxTree Syntax { get; }

        public Compilation(SyntaxTree syntax) {
            Syntax = syntax;
        }

        public EvaluationResult Evaluate() {
            var binder = new Binder();
            var boundExpression = binder.BindExpression(Syntax.Root);
            
            var diagnostics = Syntax.Diagnostics.Concat(binder.Diagnostics).ToArray();

            if (diagnostics.Any()) {
                return new EvaluationResult(diagnostics, null);
            }
            
            var evaluator = new Evaluator(boundExpression);
            var value = evaluator.Evaluate();

            return new EvaluationResult(Array.Empty<Diagnostic>(), value);
        }
    }
}
