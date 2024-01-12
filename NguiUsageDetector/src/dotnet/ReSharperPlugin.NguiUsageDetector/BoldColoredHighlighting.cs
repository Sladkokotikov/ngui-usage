using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using System.Drawing;
using JetBrains.TextControl.DocumentMarkup;

namespace ReSharperPlugin.NguiUsageDetector;

[RegisterHighlighterGroup(
    GroupId: HighlightAttributeGroupId,
    PresentableName: HighlightAttributeIdBase,
    HighlighterGroupPriority.CODE_SETTINGS)]
[RegisterHighlighter(
    Id: HighlightAttributeId,
    GroupId = HighlightAttributeGroupId,
    EffectType = EffectType.TEXT,
    ForegroundColor = "#666600",
    FontStyle = FontStyle.Bold,
    Layer = HighlighterLayer.DEADCODE + 1)]
[StaticSeverityHighlighting(Severity.INFO,
    typeof(HighlightingGroupIds.IdentifierHighlightings),
    AttributeId = HighlightAttributeId,
    Languages = CSharpLanguage.Name,
    OverlapResolve = OverlapResolveKind.ERROR)]
public class BoldColoredHighlighting(DocumentRange documentRange, string tooltip) : IHighlighting
{
    private const string HighlightAttributeIdBase = nameof(BoldColoredHighlighting) + "Base";
    private const string HighlightAttributeGroupId = HighlightAttributeIdBase + "Group";
    private const string HighlightAttributeId = nameof(BoldColoredHighlighting);

    public bool IsValid() => true;

    public DocumentRange CalculateRange() => documentRange;

    public string ToolTip => tooltip;
    public string ErrorStripeToolTip => null;
}