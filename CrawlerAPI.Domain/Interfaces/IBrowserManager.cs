using Microsoft.Playwright;

namespace CrawlerAPI.Domain.Interfaces;

public interface IBrowserManager
{
    Task<IBrowser> GetNewBrowserAsync(BrowserTypeLaunchOptions? browserTypeLaunchOptions);

    Task NavigateAsync(IPage page, string url);
}