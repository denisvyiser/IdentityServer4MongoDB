using AutoMapper;
using MongoDB.Driver;
using Project.identityserver.Application.Interfaces;
using Project.identityserver.Application.Interfaces.Services;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Notifications;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Services
{
    public interface IWriteClientStoreAppService : IWriteGenericAppService<ClientViewModel>
    {
    }
}