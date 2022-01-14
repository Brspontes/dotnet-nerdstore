using NerdStore.Enterprise.Web.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Web.Services.Handlers
{
    //Interceptador de request para adcionar token
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly IUser user;

        public HttpClientAuthorizationDelegatingHandler(IUser user)
        {
            this.user = user;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authorizationHeader = user.ObterHttpContext().Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                request.Headers.Add("Authorization", new List<string>() { authorizationHeader });
            }

            var token = user.ObterUserToken();

            if (token != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
