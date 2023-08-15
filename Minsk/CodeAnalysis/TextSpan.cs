namespace Minsk.CodeAnalysis
{
    public readonly struct TextSpan {
        public int Length { get; }
        public int Start { get; }

        public readonly int End => Start + Length;

        public TextSpan(int start, int length) {
            Start = start;
            Length = length;
        }
    }
}
