using Microsoft.Playwright;

namespace RskDemo.Ids.Tests.Integration.PageModels;

public class LoginPage : PageBase
{
    private ILocator usernameField;
    private ILocator passwordField;
    private ILocator loginButton;

    public LoginPage(IPage page, string address) : base(page, address)
    {
    }

    public async Task EnterUsername(string username) => await usernameField.FillAsync(username);

    public async Task EnterPassword(string password) => await passwordField.FillAsync(password);

    public async Task ClickLogin() => await loginButton.ClickAsync();
    
    protected override void SetupLocators(IPage page)
    {
        usernameField = Page.GetByPlaceholder("Username");
        passwordField = Page.GetByPlaceholder("Password");
        loginButton = Page.Locator(@"button[value=""login""]");
    }
}