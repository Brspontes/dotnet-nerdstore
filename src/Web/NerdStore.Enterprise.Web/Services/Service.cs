using NerdStore.Enterprise.Web.Extensions;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Web.Services
{
    public abstract class Service
    {
        protected StringContent ObterConteudo(object dado) =>
            new StringContent(JsonSerializer.Serialize(dado),
                Encoding.UTF8,
                "application/json");

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage response) =>
            JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpRequestException(response.StatusCode);

                case 400:
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
