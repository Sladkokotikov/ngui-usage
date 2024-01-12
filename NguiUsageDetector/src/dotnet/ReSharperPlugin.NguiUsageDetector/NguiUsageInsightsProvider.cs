using System;
using System.Collections.Generic;
using System.Net.Http;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Daemon.CodeInsights;
using JetBrains.Rider.Model;

namespace ReSharperPlugin.NguiUsageDetector;

[SolutionComponent]
public class NguiUsageInsightsProvider : ICodeInsightsProvider
{
    public bool IsAvailableIn(ISolution solution) => true;

    public void OnClick(CodeInsightHighlightInfo highlightInfo, ISolution solution)
    {
        SendRequestToUnity("Ngui usage click!");
    }

    public void OnExtraActionClick(CodeInsightHighlightInfo highlightInfo, string actionId, ISolution solution)
    {
        SendRequestToUnity("Ngui usage extra click!");
    }
    
    private async void SendRequestToUnity(string data)
    {
        using var httpClient = new HttpClient();
        var apiUrl = "http://localhost:7020/";

        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
            request.Content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            await httpClient.SendAsync(request);
        }
        catch (Exception)
        {
            //
        }
    }

    public string ProviderId => nameof(NguiUsageInsightsProvider);
    public string DisplayName => "Ngui Usage Detector";
    public CodeVisionAnchorKind DefaultAnchor => CodeVisionAnchorKind.Top;

    public ICollection<CodeVisionRelativeOrdering> RelativeOrderings
        => new List<CodeVisionRelativeOrdering> { new CodeVisionRelativeOrderingFirst() };
}