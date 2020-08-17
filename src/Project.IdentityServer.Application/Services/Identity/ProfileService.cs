using AutoMapper;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using MongoDB.Driver;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ProfileService(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();

            //Logger.LogDebug("Get profile called for subject {subject} from client {client} with claim types {claimTypes} via {caller}",
            //    context.Subject.GetSubjectId(),
            //    context.Client.ClientName ?? context.Client.ClientId,
            //    context.RequestedClaimTypes,
            //    context.Caller);

           
            var user = await FindUserBySubject(sub);

            if(user.Claims.Any())
            {
                context.IssuedClaims = user.Claims.Select(c=> new Claim(c.Type,c.Value)).ToList();
            }
            else
            {
                var claims = new List<Claim>
                {
                new Claim("role", "dataEventRecords.admin"),
                new Claim("role", "dataEventRecords.user"),
                new Claim("username", user.Username),
                new Claim("email", user.Email)
                };

                context.IssuedClaims = claims;
            }

           
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();

            var user = await FindUserBySubject(sub);

            context.IsActive = user != null;
        }

        public async Task<User> FindUserBySubject(string subjectId)
        {
            
            var builder = Builders<User>.Filter;

            FilterDefinition<User> filter = null;

            filter = builder.Where(c => c.SubjectId == subjectId);

            var query = new GetUserQuery()
            {
                Filter = filter
            };

            var user = await _mediator.SendQuery(query);

            return user;
        }
    }
}
