﻿using JetBrains.Annotations;
using LogoFX.Client.Testing.EndToEnd.FakeData.Modularity;
using LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders;
using Solid.Practices.IoC;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Infra.Providers
{    
    [UsedImplicitly]
    public class Module : ProvidersModuleBase<IIocContainer>
    {
        protected override void OnRegisterProviders(IIocContainer iocContainer)
        {
            base.OnRegisterProviders(iocContainer);
            RegisterAllBuilders(iocContainer, LoginProviderBuilder.CreateBuilder);
            RegisterAllBuilders(iocContainer, WarehouseProviderBuilder.CreateBuilder);            
        }
    }
}
