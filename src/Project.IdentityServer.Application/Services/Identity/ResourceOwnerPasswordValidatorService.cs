using AutoMapper;
using IdentityModel;
using IdentityServer4.Test;
using IdentityServer4.Validation;
using MongoDB.Driver;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Services
{
    public class ResourceOwnerPasswordValidatorService : IResourceOwnerPasswordValidator
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ResourceOwnerPasswordValidatorService(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {

            var builder = Builders<User>.Filter;

            FilterDefinition<User> filter = null;

            filter = builder.Where(c => c.Username == context.UserName & c.Password == context.Password);

            var query = new GetUserQuery()
            {
                Filter = filter

            };

            var user = await _mediator.SendQuery(query);

            if (user != null)
            {                
                context.Result = new GrantValidationResult(user.SubjectId, OidcConstants.AuthenticationMethods.Password);
            }

            
        }
    }
}
