using Crawler;
using CrawlerAPI.Domain.Interfaces;
using Microsoft.Playwright;

namespace CrawlerAPI.Domain;

public class PlaywrightCrawlerService: ICrawlerService
{
    private readonly IBrowserManager _browserManager;
    private List<string> _crawledLinks;

    public PlaywrightCrawlerService(IBrowserManager browserManager)
    {
        _browserManager = browserManager;
    }
    
    public async Task<SourceResponse> GetSourceCode(CrawlRequest crawlRequest)
    {
        await using var browser = await _browserManager.GetNewBrowserAsync(null);
        var page = await browser.NewPageAsync();

        await _browserManager.NavigateAsync(page, crawlRequest.Model.Url);

        var pageContent = await page.ContentAsync();

        return await Task.FromResult(new SourceResponse()
        {
            Result = pageContent,
        });
    }

    public async Task StartCrawling (CrawlRequest crawlRequest)
    {
        await using var browser = await _browserManager.GetNewBrowserAsync(null);
        var page = await browser.NewPageAsync();

        await page.RouteAsync("", (route =>
        {
            if (route.Request.IsNavigationRequest)
            {
                route.AbortAsync();
            }

            route.ContinueAsync();
        }));

        await page.AddInitScriptAsync(scriptPath: "../Scripts/simulator.js");
        
        await _browserManager.NavigateAsync(page, crawlRequest.Model.Url);
        
        await page.EvaluateAsync("()=>simulatePage()");
    }

    private void RouteHandler(IRoute route)
    {
        _crawledLinks.Add(route.Request.Url);
        
        
    }
}