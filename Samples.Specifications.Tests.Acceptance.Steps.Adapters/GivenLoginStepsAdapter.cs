﻿using Samples.Specifications.Tests.Steps;
using TechTalk.SpecFlow;

namespace Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    class GivenLoginStepsAdapter
    {
        public GivenLoginSteps GivenLoginSteps { get; set; }

        public GivenLoginStepsAdapter(GivenLoginSteps givenLoginSteps)
        {
            GivenLoginSteps = givenLoginSteps;
        }

        [Given(@"I am able to log in successfully with username '(.*)' and password '(.*)'")]
        public void GivenIAmAbleToLogInSuccessfullyWithUsernameAndPassword(string userName, string password)
        {
            GivenLoginSteps.SetupAuthenticatedUserWithCredentials(userName, password);            
        }
    }
}
