using Microsoft.Playwright;

namespace MathLibrary.Tests.Pages;

public class JobsPage
{
    private readonly IPage _page;

    public JobsPage(IPage page)
    {
        _page = page;
    }

    private ILocator VacancyItems => _page.Locator(".vacancy");

    public async Task OpenAsync()
    {
        await _page.GotoAsync("https://jobs.dou.ua/");
    }

    public async Task<int> GetVacanciesCount()
    {
        return await VacancyItems.CountAsync();
    }

    public async Task<bool> HasVacancies()
    {
        return await VacancyItems.First.IsVisibleAsync();
    }
}