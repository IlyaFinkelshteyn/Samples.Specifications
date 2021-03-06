﻿using LogoFX.Client.Testing.EndToEnd.White;
using Samples.Specifications.Tests.Domain;
#if REAL
using Samples.Specifications.Tests.Steps.Helpers;
#endif

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    class SetupService : ISetupService
    {
#if REAL
        private readonly ISetupHelper _setupHelper;

        public SetupService(ISetupHelper setupHelper)
        {
            _setupHelper = setupHelper;
        }

        public void Setup()
        {
            _setupHelper.Initialize();
        }
#endif

#if FAKE        
        public void Setup()
        {            
        }
#endif
    }

    class TeardownService : ITeardownService
    {
        public void Teardown()
        {
            ApplicationContext.Application?.Dispose();
        }
    }
}
