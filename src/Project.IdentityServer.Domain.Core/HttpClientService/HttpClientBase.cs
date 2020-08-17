using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Interfaces.HttpClientService;
using Project.identityserver.Domain.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.Core.HttpClientService
{
    public abstract class HttpClientBase<T> : IHttpClientBase<T> where T : class
    {
        private readonly IHttpClientFactory _clientFactory;

        private readonly HttpClient client;

        private readonly IMediatorHandler _mediator;
        public HttpClientBase(IHttpClientFactory clientFactory, IMediatorHandler mediator)
        {
            _clientFactory = clientFactory;

            client = _clientFactory.CreateClient(this.GetType().Name);

            _mediator = mediator;
        }

        public async Task<T> OnGet(IDictionary<string, string> headers, string uri)
        {
            T obj = default(T);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<T>(responseStream);
            }
            else
            {
              await  _mediator.RaiseEvent(new DomainNotification(this.GetType().Name, "Dados não retornados."));

                return obj;
            }
        }

        public async Task<List<T>> OnGetList(IDictionary<string, string> headers, string uri)
        {
            //var request = new HttpRequestMessage(HttpMethod.Get,
            //    "repos/aspnet/AspNetCore.Docs/pulls");

            List<T> obj = null;

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<T>>(responseStream);
            }
            else
            {
                await _mediator.RaiseEvent(new DomainNotification(this.GetType().Name, "Dados não retornados."));
                return obj;
            }
        }
                     
    }
}
