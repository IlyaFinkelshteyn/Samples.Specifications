﻿using System;
using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.Specifications.Client.Launcher.Shared;

namespace Samples.Specifications.Client.Launcher
{
    partial class App
    {
        public App()
        {            
            var bootstrapper = new AppBootstrapper(new ExtendedSimpleContainerAdapter());
            bootstrapper.UseResolver().UseShared().Initialize();            
        }
    }
}
