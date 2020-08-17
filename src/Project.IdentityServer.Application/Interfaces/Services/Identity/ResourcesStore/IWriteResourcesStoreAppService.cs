﻿using Project.identityserver.Application.ViewModels;
using Project.identityserver.Application.Interfaces.Services;

namespace Project.identityserver.Application.Services
{
    public interface IWriteResourcesStoreAppService : IWriteGenericAppService<ResourcesViewModel>
    { 
    }
}