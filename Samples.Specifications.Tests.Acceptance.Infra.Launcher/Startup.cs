﻿using BoDi;
using LogoFX.Client.Testing.EndToEnd.SpecFlow;
using TechTalk.SpecFlow;

namespace Samples.Specifications.Tests.Acceptance.Infra.Launcher
{
    /// <summary>
    /// Represents SpecFlow bridge which performs the required registrations
    /// for screen objects and application services
    /// </summary>
    [Binding]
    class Startup : EndToEndTestsBase
    {
        public Startup(IObjectContainer objectContainer)
        {
            var containerAdapter = new ObjectContainerAdapter(objectContainer);
            var bootstrapper =
                new Bootstrapper(containerAdapter)
                .Use(new RegisterCompositionModulesMiddleware<Bootstrapper>());            
            bootstrapper.Initialize();            
        }                       
    }
}
