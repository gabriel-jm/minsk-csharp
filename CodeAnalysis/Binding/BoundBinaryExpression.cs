using System;

namespace Minsk.CodeAnalysis.Binding
{
    internal sealed class BoundBinaryExpression : BoundExpression {
        public BoundBinaryOperatorKind OperatorKind { get; }
        public BoundExpression Left { get; }
        public BoundExpression Right { get; }
        public override Type Type => Left.Type;
        public override BoundNodeKind Kind => BoundNodeKind.BinaryExpression;

        public BoundBinaryExpression(BoundExpression left, BoundBinaryOperatorKind operatorKind, BoundExpression right) {
            OperatorKind = operatorKind;
            Left = left;
            Right = right;
        }
    }
}