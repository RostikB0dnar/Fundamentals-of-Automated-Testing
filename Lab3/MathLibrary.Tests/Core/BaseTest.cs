using Microsoft.Playwright;

namespace MathLibrary.Tests.Core;

public class BaseTest : IAsyncLifetime
{
    protected IPlaywright Playwright;
    protected IBrowser Browser;
    protected IPage Page;

    public virtual async Task InitializeAsync()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        Page = await Browser.NewPageAsync();
    }

    public async Task DisposeAsync()
    {
        await Browser.CloseAsync();
        Playwright.Dispose();
    }
}