using MathLibrary.Tests.Core;
using Microsoft.Playwright;

namespace MathLibrary.Tests.Tests;

public class DouE2ETests : BaseTest
{
    private IBrowserContext _context;
    
    [Fact]
    public async Task Search_QA_ShouldReturnResults()
    {
        await Page.Locator("input[name='search']").FillAsync("QA");
        await Page.Keyboard.PressAsync("Enter");

        await Page.WaitForSelectorAsync(".lt > li");

        var results = await Page.Locator(".lt > li").CountAsync();
        Assert.True(results > 0);
    }
    
    [Fact]
    public async Task Open_FirstVacancy_ShouldDisplayPage()
    {
        await Page.WaitForSelectorAsync(".lt > li a");

        await Page.Locator(".lt > li a").First.ClickAsync();

        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        var title = await Page.TitleAsync();

        Assert.False(string.IsNullOrEmpty(title));
        Assert.Contains("DOU", title);
    }
    
    [Fact]
    public async Task QA_Category_ShouldShowVacancies()
    {
        await Page.GotoAsync(
            "https://jobs.dou.ua/vacancies/?category=QA",
            new() { WaitUntil = WaitUntilState.NetworkIdle }
        );

        await Page.WaitForSelectorAsync(".lt > li");

        var items = await Page.Locator(".lt > li").CountAsync();

        Assert.True(items > 0);
    }
    
}