﻿using Samples.Specifications.Tests.Acceptance.Contracts;

namespace Samples.Specifications.Tests.Acceptance.Steps
{
    public class GeneralSteps
    {
        private readonly IStartClientApplicationService _startClientApplicationService;

        public GeneralSteps(IStartClientApplicationService startClientApplicationService)
        {
            _startClientApplicationService = startClientApplicationService;
        }

        public void WhenIOpenTheApplication()
        {
            _startClientApplicationService.StartApplication();
        }
    }
}
