using Crawler;

namespace CrawlerAPI.Domain.Interfaces;

public interface ICrawlerService
{
    Task<SourceResponse> GetSourceCode(CrawlRequest crawlRequest);

    Task StartCrawling(CrawlRequest crawlRequest);
}