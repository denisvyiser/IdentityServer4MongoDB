﻿using Project.identityserver.Application.Interfaces.Services;
using Project.identityserver.Application.ViewModels;

namespace Project.identityserver.Application.Interfaces
{
    public interface IWriteUserAppService : IWriteGenericAppService<UserViewModel>
    {
       
    }
}