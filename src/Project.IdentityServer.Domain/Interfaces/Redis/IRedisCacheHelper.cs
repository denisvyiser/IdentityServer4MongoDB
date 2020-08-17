using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.Interfaces.Redis
{
    public interface IRedisCacheHelper
    {
        Task<bool> Get(string key);

    }
}
