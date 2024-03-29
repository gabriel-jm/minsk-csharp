using System.Linq;
using System.Collections.Generic;

namespace Minsk.CodeAnalysis.Syntax {
    public class SyntaxToken : SyntaxNode {
        public override SyntaxKind Kind { get; }
        public int Position { get; }
        public string Text { get; }
        public object Value { get; }

        public SyntaxToken(SyntaxKind kind, int position, string text, object value) {
            Kind = kind;
            Position = position;
            Text = text;
            Value = value;
        }

        public TextSpan Span => new TextSpan(Position, Text.Length);

        public override IEnumerable<SyntaxNode> GetChildren() {
            return Enumerable.Empty<SyntaxNode>();
        }
    }
}