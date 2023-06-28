using Microsoft.Playwright;
using RskDemo.Ids.Tests.Integration.PageModels;
using System;
using System.Net.Sockets;
using RSKDockerDemo.IntegrationTests.Helpers;
using TechTalk.SpecFlow;

namespace RSKDockerDemo.IntegrationTests.StepDefinitions
{
    [Binding]
    public class IdentityServerLogInStepDefinitions
    {
        private readonly IBrowser webBrowser;
        private LoginPage loginPage;

        public IdentityServerLogInStepDefinitions(IBrowser webBrowser)
        {
            this.webBrowser = webBrowser;
            this.loginPage = null;
        }

        [Given(@"I am on the login page")]
        public async Task GivenIAmOnTheLoginPage()
        {
            var browserPage = await webBrowser.NewPageAsync();
            var address = DockerHelpers.InDocker() ? "ids:5001/account/login" : "http://localhost:5001/account/login.";
            this.loginPage = new LoginPage(browserPage, address);
            await loginPage.GotoAsync();
        }

        [When(@"I enter a username of alice")]
        public async Task WhenIEnterAUsernameOfAlice() => await loginPage.EnterUsername("alice");

        [When(@"I enter a password of alice")]
        public async Task WhenIEnterAPasswordOfAlice() => await loginPage.EnterPassword("alice");

        [When(@"I click the login button")]
        public async Task WhenIClickTheLoginButton() => await loginPage.ClickLogin();

        [Then(@"I should be loged in")]
        public async Task ThenIShouldBeLogedIn() => await Assertions.Expect(loginPage.Page).ToHaveTitleAsync("Duende IdentityServer");
    }
}