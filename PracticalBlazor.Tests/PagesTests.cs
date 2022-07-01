using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using PracticalBlazor.Pages;
using PracticalBlazor.Services;
using Xunit;

namespace PracticalBlazor.Tests;

public class PagesTests
{
    [Fact]
    public void ThankYouPage_OnVisit_ShouldShowContactInformation()
    {
        // Arrange
        using var testContext = new TestContext();
        testContext
            .Services
            .AddSingleton(Mock.Of<IGlobalNavigationService>())
            .AddSingleton(Mock.Of<IGlobalDomEventService>());

        // Act
        var component = testContext.RenderComponent<ThankYou>();

        // Assert
        Assert.Equal(Texts.PresenterContact, component.Find($"#contact").TextContent);
    }
}
