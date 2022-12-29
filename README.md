# ebay-scraper

`ebay-scraper` (or `EbayScraper`) is a basic web scraping framework written in C# and targeting the .NET 6.0 LTS framework which is intended to simplify the algorithmic gathering of public eBay listing information. Intended to minimize framework bulk, `ebay-scraper` only requires two external dependencies, [`HttpAgilityPack`](https://html-agility-pack.net/) and [`PuppeteerSharp`](https://github.com/hardkoded/puppeteer-sharp). 

## Disclaimer

Web scraping of publicly-available information, while [entirely legal](https://blog.apify.com/is-web-scraping-legal/), places a significant demand on the target website's servers. As such, many companies, eBay included, have amended their terms of service (ToS) or other user agreements to forbid the practice of algorithmically crawling or scraping for information. More specifically, eBay's [user agreement](https://www.ebay.com/help/policies/member-behaviour-policies/user-agreement?id=4259#3) forbids the "...use [of] any robot, spider, scraper, data mining tools, data gathering and extraction tools, or other automated means to access our Services for any purpose..." As such, this code is being furnished as-is for educational or experimental purposes only, with any use in public or "production" roles highly discouraged by the author.

In order to build an exemplary web scraping package which is not only legal, but also ethical, acting as a "good citizen of the Web", Amber Zamora's four guidelines on web scraping<sup>[<a href="#footnote1">1</a>]</sup> were followed during the construction of this framework. Summarized, they are:

1. The application must be a "good citizen of the Web" and avoid overburdening the target website. `ebay-scraper` abides by this element through use of configurable timeouts (slowing the rate of sent queries) and through careful design to eliminate unnecessary querying of eBay's servers.
2. The information gathered (listing data such as listing title, price, general location, and sale format) are publicly accessible and not located behind any sort of login, authentication, or any other technological stop.
3. The information copied was primarily factual in nature and uninfringing on others' rights - `ebay-scraper` implements this guideline by ignoring any fields which carry personally-identifiable information, such as eBay seller usernames, highly-specific locations, and other such information.
4. The information was not used for purposes of establishing a competitive advantage over the target - `ebay-scraper` was originally designed to assist the author in establishing some average prices of items to purchase, and has, at no point, been intended to assist in the establishment of a similar e-commerce service.

Beyond the legal and ethical disclaimers above, it should be noted that `ebay-scraper` is subject to all the usual pitfalls of web-scraping frameworks - namely, that it is hardcoded with a specific site format and structure in mind. If eBay decides to significantly alter their HTML page structure, this framework will cease to function properly until manually patched by the author or another interested party. The author is not responsible for any software bugs, errors, or loss of functionality that may be caused by changes to the eBay page structure, and anyone requiring bulletproof, production-grade solutions to the problems `ebay-scraper` is designed to address should instead consider the [official eBay APIs](https://developer.ebay.com/develop/apis).

## Installation 

## Usage

First, create the options argument to pass through to `Query`:

```csharp
var options = new RunOptions() {
    ChromePath    = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
    TimeoutLength = 1000,
    CsvOut        = true,
    CsvFilename   = "listing_data.csv"
};
```

Then, the `Query` object can be instantiated and the various methods used to operate on it in LINQ-esque fashion:

```csharp
Query query = new Query(options)
            .AddKeywords("desktop computer")
            .SetMinimumPrice(50.0m)
            .SetMaximumPrice(500.0m)
            .SaleFormat(ListingFormat.BuyItNow);
var response = await query.Execute();
```

The `response` variable should be returned of type [`List<Listing>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0); further information may be found in the [API documentation](https://github.com/ecfedele/ebay-scraper/blob/main/APIDOC.md).

## Notes

<ol>
    <li id="#footnote1">See Zamora, A. (2019). Making room for big data: Web scraping and an affirmative right to access publicly available information online. <i>Journal of Business, Entrepreneurship and the Law</i>. <i>12</i>(1). 203-227. <a href="https://digitalcommons.pepperdine.edu/cgi/viewcontent.cgi?article=1194&context=jbel">https://digitalcommons.pepperdine.edu/cgi/viewcontent.cgi?article=1194&context=jbel</a>. In particular, note the guidelines listed in Section VI (p. 226).</li>
</ol> 