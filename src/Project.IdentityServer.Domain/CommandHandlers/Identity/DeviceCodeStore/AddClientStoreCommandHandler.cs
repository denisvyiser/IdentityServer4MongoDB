﻿using AutoMapper;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Events;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Core.GenericCommandHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

namespace Project.identityserver.Domain.CommandHandlers
{
    public class AddDeviceCodeStoreCommandHandler : CommandHandlerAdd<AddDeviceCodeStoreCommand, DeviceCodeStore, AddedDeviceCodeStoreEvent>
    {
        public AddDeviceCodeStoreCommandHandler(IMediatorHandler mediator, IMapper mapper, IWriteDeviceCodeStoreMongoDbRepository repository) : base(mediator, mapper, repository)
        {

        }

        //public override Expression<Func<DeviceCodeStore, bool>> generateQuery(DeviceCodeStore entity) => c => c.Description == entity.Description;
        
    }
}