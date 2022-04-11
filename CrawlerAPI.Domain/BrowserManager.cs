using CrawlerAPI.Domain.Interfaces;
using Microsoft.Playwright;

namespace CrawlerAPI.Domain;

public class BrowserManager: IBrowserManager
{
    public async Task<IBrowser> GetNewBrowserAsync(BrowserTypeLaunchOptions? browserTypeLaunchOptions)
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(browserTypeLaunchOptions);

        return browser;
    }

    public async Task NavigateAsync(IPage page, string url)
    {
        await page.GotoAsync(url, new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle,
            Timeout = 30000,
        });
    }
}