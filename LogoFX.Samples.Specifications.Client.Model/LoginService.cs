﻿using System.Threading.Tasks;
using JetBrains.Annotations;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Providers;
using LogoFX.Samples.Specifications.Client.Model.Contracts;
using LogoFX.Samples.Specifications.Client.Model.Shared;

namespace LogoFX.Samples.Specifications.Client.Model
{
    [UsedImplicitly]
    class LoginService : ServiceBase, ILoginService
    {
        private readonly ILoginProvider _loginProvider;

        public LoginService(ILoginProvider loginProvider)
        {
            _loginProvider = loginProvider;
        }

        public async Task LoginAsync(string username, string password)
        {
            await RunAsync(() =>
            {
                _loginProvider.Login(username, password);
                UserContext.Current = new User(username);
            });
        }
    }
}