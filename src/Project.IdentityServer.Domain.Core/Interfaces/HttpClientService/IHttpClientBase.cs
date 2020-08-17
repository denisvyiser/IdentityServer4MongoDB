using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.Core.Interfaces.HttpClientService
{
    public interface IHttpClientBase<T> where T : class
    {
        Task<T> OnGet(IDictionary<string, string> headers, string uri);

        Task<List<T>> OnGetList(IDictionary<string, string> headers, string uri);
    }
}
