using Microsoft.Playwright;

namespace MathLibrary.Tests;

public class DouUiTests : IAsyncLifetime
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IPage _page;

    private const string Url = "https://jobs.dou.ua/";

    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            Channel = "chrome"
        });

        _page = await _browser.NewPageAsync();
        await _page.GotoAsync(Url);
    }

    public async Task DisposeAsync()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }

    [Fact]
    public async Task Vacancies_ShouldBeVisible()
    {
        await _page.WaitForSelectorAsync(".lt", new() { Timeout = 60000 });

        var vacancies = await _page.QuerySelectorAsync(".lt");
        Assert.NotNull(vacancies);
    }

    [Fact]
    public async Task Vacancies_Count_ShouldBeGreaterThanZero()
    {
        await _page.WaitForSelectorAsync(".lt > li", new() { Timeout = 60000 });

        var items = await _page.QuerySelectorAllAsync(".lt > li");
        Assert.True(items.Count > 0);
    }

    [Fact]
    public async Task Filter_QA_ShouldShowResults()
    {
        await _page.GotoAsync("https://jobs.dou.ua/vacancies/?category=QA",
            new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });

        await _page.WaitForSelectorAsync(".lt > li", new() { Timeout = 60000 });

        var jobs = await _page.QuerySelectorAllAsync(".lt > li");
        Assert.True(jobs.Count > 0);
    }

    [Fact]
    public async Task Page_ShouldHaveCorrectTitle()
    {
        var title = await _page.TitleAsync(); Assert.Contains("DOU", title);
    }
    
    [Fact]
    public async Task Search_QA_ShouldReturnResults()
    {
        await _page.GotoAsync("https://jobs.dou.ua/vacancies/?search=QA",
            new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });

        await _page.WaitForSelectorAsync(".lt > li", new() { Timeout = 60000 });

        var jobs = await _page.QuerySelectorAllAsync(".lt > li");
        Assert.True(jobs.Count > 0);
    }
}