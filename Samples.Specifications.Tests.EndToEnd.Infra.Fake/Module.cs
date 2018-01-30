﻿using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd;
using LogoFX.Client.Testing.EndToEnd.FakeData;
using Samples.Specifications.Client.Data.Fake.Shared;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Fake
{
    class Module : ICompositionModule<IDependencyRegistrator>
    {                
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator
                .AddSingleton<IStartApplicationService, StartApplicationService.WithFakeProviders>()
                .AddSingleton<IBuilderRegistrationService, BuilderRegistrationService>()
                .RegisterBuilders();                        
        }        
    }
}
