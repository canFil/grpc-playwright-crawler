using Crawler;
using Grpc.Core;

namespace CrawlerAPI.Services;

public class CrawlerService: CrawlService.CrawlServiceBase
{
    public override async Task<SourceResponse> GetSourceCode(CrawlRequest request, ServerCallContext context)
    {
        // using var playwright = await Playwright.CreateAsync();
        // await using var browser = await playwright.Chromium.LaunchAsync();
        // var page = await browser.NewPageAsync();
        //
        // await page.GotoAsync(request.Model.Url, new PageGotoOptions
        // {
        //     WaitUntil = WaitUntilState.NetworkIdle,
        //     Timeout = 30000,
        // });
        //
        // await page.RouteAsync("", RouteHandler);
        //
        return await Task.FromResult(new SourceResponse());
    }
}