using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task MyTest()
    {
        await Page.GotoAsync("https://ca3devops.azurewebsites.net/");
        await Page.GetByRole(AriaRole.List).GetByRole(AriaRole.Link, new() { Name = "Privacy" }).ClickAsync();

        // Verify that the navigation was successful
        Assert.That(Page.Url, Is.EqualTo("https://ca3devops.azurewebsites.net/Privacy"));
    }
}