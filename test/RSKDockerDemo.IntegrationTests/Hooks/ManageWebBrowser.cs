using BoDi;
using Microsoft.Playwright;

namespace RSKDockerDemo.IntegrationTests.Hooks;

/// <summary>
/// A hook to Create and teardown a web browser managed by Playwright.
/// </summary>
[Binding]
public class ManageWebBrowser
{
    private readonly IObjectContainer objectContainer;

    public ManageWebBrowser(IObjectContainer objectContainer) => this.objectContainer= objectContainer;

    [BeforeScenario("RequiresChrome")]
    public async Task StartChromeWebBrowser()
    {
     var    playwright = await Playwright.CreateAsync();
     objectContainer.RegisterInstanceAs<IPlaywright>(playwright);
         var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
         {
             Headless =true,
             Channel ="chrome"
         });
         objectContainer.RegisterInstanceAs<IBrowser>(browser);
    }

    [AfterScenario("RequiresChrome")]
    public async Task CloseDownChromeBrowser()
    {
        if (objectContainer.Resolve<IBrowser>() is { } browser)
        {
            await browser.DisposeAsync();
        }

        if (objectContainer.Resolve<IPlaywright>() is { } playwright)
        {
            playwright.Dispose();
        }
    }
}