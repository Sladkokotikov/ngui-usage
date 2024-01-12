using System.Collections.Generic;
using JetBrains.ReSharper.Daemon.CodeInsights;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Rider.Model;

namespace ReSharperPlugin.NguiUsageDetector;

[ElementProblemAnalyzer(typeof(ICSharpFunctionDeclaration))]
public class NguiUsageAnalyzer(NguiUsageInsightsProvider nguiUsageInsightsProvider)
    : ElementProblemAnalyzer<ICSharpFunctionDeclaration>
{
    protected override void Run(ICSharpFunctionDeclaration element, ElementProblemAnalyzerData data,
        IHighlightingConsumer consumer)
    {
        if (!UsedByNgui(element))
            return;
        consumer.AddHighlighting(new CodeInsightsHighlighting(
            range: element.GetNameDocumentRange(),
            displayText: "Used in NGUI",
            tooltipText: "Click to find usages in Unity",
            moreText: "Click to find usages in Unity",
            provider: nguiUsageInsightsProvider,
            elt: element.DeclaredElement,
            icon: null));
        consumer.AddHighlighting(new BoldColoredHighlighting(element.GetNameDocumentRange(), "Used in NGUI"));
    }

    private bool UsedByNgui(ICSharpFunctionDeclaration element)
    {
        return element.DeclaredName.Contains("He");
    }
}