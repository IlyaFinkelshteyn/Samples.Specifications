﻿using System.Collections.Generic;
using Samples.Specifications.Server.Domain.Models;

namespace Samples.Specifications.Server.Domain.Services.Storage
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}