﻿using Samples.Specifications.Client.Tests.Integration.Infra;
using Samples.Specifications.Tests.Steps;
using Xunit;

namespace Samples.Specifications.Client.Tests.Integration
{
    public class LoginFeature : IntegrationTestsBaseWithActivation
    {
        [Fact]
        public void LoginScreenIsDisplayedFirst()
        {
            var generalSteps = Resolver.Resolve<GeneralSteps>();
            generalSteps.WhenIOpenTheApplication();

            var loginSteps = Resolver.Resolve<LoginSteps>();
            loginSteps.ThenTheLoginScreenIsDisplayed();
        }

        [Fact]
        public void NavigateToTheMainScreenWhenTheLoginIsSuccessful()
        {
            var givenLoginSteps = Resolver.Resolve<GivenLoginSteps>();
            var userName = "Admin";
            var password = "1234";
            givenLoginSteps.SetupAuthenticatedUserWithCredentials(userName, password);
            givenLoginSteps.SetupLoginSuccessfullyWithUsername(userName);

            var generalSteps = Resolver.Resolve<GeneralSteps>();
            generalSteps.WhenIOpenTheApplication();
            var loginSteps = Resolver.Resolve<LoginSteps>();
            loginSteps.WhenISetTheUsernameTo(userName);
            loginSteps.WhenISetThePasswordTo(password);
            loginSteps.WhenILogInToTheSystem();

            var mainSteps = Resolver.Resolve<MainSteps>();
            mainSteps.ThenApplicationNavigatesToTheMainScreen();
        }
    }
}
