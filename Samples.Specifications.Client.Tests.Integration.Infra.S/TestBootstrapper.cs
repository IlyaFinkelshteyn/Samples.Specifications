﻿using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModelFactory.Unity;

namespace Samples.Specifications.Client.Tests.Integration.Infra
{
    public class TestBootstrapper : TestBootstrapperContainerBase<UnityContainerAdapter>
        .WithRootObject<ShellViewModel>
    {
        public TestBootstrapper() :
            base(new UnityContainerAdapter(), new BootstrapperCreationOptions
            {
                UseApplication = false,
                ReuseCompositionInformation = true
            })
        {			
            this.UseResolver().UseViewModelCreatorService().UseViewModelFactory();
        }

        public override string[] Prefixes
        {
            get
            {
                return new[] { "Samples.Specifications.Client.Presentation", "Samples.Client.Model", "Samples.Specifications.Client.Data", "Samples.Specifications.Client.Tests", "Samples.Client.Tests", "Samples.Specifications.Tests.Steps" };
            }
        }
    }
}