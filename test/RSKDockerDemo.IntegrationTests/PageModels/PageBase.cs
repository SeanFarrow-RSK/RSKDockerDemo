using Microsoft.Playwright;

namespace RskDemo.Ids.Tests.Integration.PageModels;

public abstract class PageBase
{
    private readonly string address;
    
    public IPage Page { get; }

    protected PageBase(IPage page, string address)
    {
        Page = page;
        this.address = address;
    }

    public async Task GotoAsync()
    {
        await Page.GotoAsync(this.address);
        SetupLocators(Page);
    }

    protected abstract void SetupLocators(IPage page);
    }