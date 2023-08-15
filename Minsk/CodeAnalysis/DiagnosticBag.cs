using System.Collections;
using Minsk.CodeAnalysis.Syntax;

namespace Minsk.CodeAnalysis;

internal sealed class DiagnosticBag : IEnumerable<Diagnostic> {
    private readonly List<Diagnostic> _diagnostics = new List<Diagnostic>();

    public IEnumerator<Diagnostic> GetEnumerator() => _diagnostics.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void AddRange(DiagnosticBag diagnostics) {
        _diagnostics.AddRange(diagnostics._diagnostics);
    }

    public void Report(TextSpan span, string message) {
        var diagnostic = new Diagnostic(span, message);
        _diagnostics.Add(diagnostic);
    }

    public void ReportInvalidNumber(TextSpan span, string text, Type type) {
        var message = $"The number {text} isn't valid {type}.";
        Report(span, message);
    }

    public void ReportBadCharacter(int position, char character) {
        var message = $"bad character input: '{character}'.";
        Report(new TextSpan(position, 1), message);
    }

    public void ReportUnexpectedToken(TextSpan span, SyntaxKind kind, SyntaxKind expectedKind)
    {
        var message = $"unexpected token <{kind}>, expected <{expectedKind}>.";
        Report(span, message);
    }
}
