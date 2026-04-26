using MathLibrary.Tests.Core;
using MathLibrary.Tests.Pages;

namespace MathLibrary.Tests.Tests;

public class DouUiTests : BaseTest
{
    private JobsPage _jobsPage;

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();
        _jobsPage = new JobsPage(Page);
    }

    [Fact]
    public async Task Page_Title()
    {
        await _jobsPage.OpenAsync();

        var title = await Page.TitleAsync();

        Assert.Contains("DOU", title);
    }

    [Fact]
    public async Task Vacancies_AreVisible()
    {
        await _jobsPage.OpenAsync();

        Assert.True(await _jobsPage.HasVacancies());
    }

    [Fact]
    public async Task Vacancies_Count()
    {
        await _jobsPage.OpenAsync();

        var count = await _jobsPage.GetVacanciesCount();

        Assert.True(count > 0);
    }

    [Fact]
    public async Task Search_QA()
    {
        await Page.GotoAsync("https://jobs.dou.ua/vacancies/?search=QA");

        var count = await _jobsPage.GetVacanciesCount();

        Assert.True(count >= 0);
    }

    [Fact]
    public async Task Filter_Results()
    {
        await Page.GotoAsync("https://jobs.dou.ua/vacancies/?category=QA");

        var count = await _jobsPage.GetVacanciesCount();

        Assert.True(count > 0);
    }
}