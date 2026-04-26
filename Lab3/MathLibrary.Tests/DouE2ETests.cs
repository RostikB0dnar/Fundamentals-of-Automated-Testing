using Microsoft.Playwright;

namespace MathLibrary.Tests;

public class DouE2ETests : IAsyncLifetime
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IBrowserContext _context;
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

        _context = await _browser.NewContextAsync();
        _page = await _context.NewPageAsync();

        await _page.GotoAsync(Url, new() { WaitUntil = WaitUntilState.NetworkIdle });
    }

    public async Task DisposeAsync()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
    
    [Fact]
    public async Task Search_QA_ShouldReturnResults()
    {
        await _page.Locator("input[name='search']").FillAsync("QA");
        await _page.Keyboard.PressAsync("Enter");

        await _page.WaitForSelectorAsync(".lt > li");

        var results = await _page.Locator(".lt > li").CountAsync();
        Assert.True(results > 0);
    }
    
    [Fact]
    public async Task Open_FirstVacancy_ShouldDisplayPage()
    {
        await _page.WaitForSelectorAsync(".lt > li a");

        await _page.Locator(".lt > li a").First.ClickAsync();

        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        var title = await _page.TitleAsync();

        Assert.False(string.IsNullOrEmpty(title));
        Assert.Contains("DOU", title);
    }
    
    [Fact]
    public async Task QA_Category_ShouldShowVacancies()
    {
        await _page.GotoAsync(
            "https://jobs.dou.ua/vacancies/?category=QA",
            new() { WaitUntil = WaitUntilState.NetworkIdle }
        );

        await _page.WaitForSelectorAsync(".lt > li");

        var items = await _page.Locator(".lt > li").CountAsync();

        Assert.True(items > 0);
    }
    
}