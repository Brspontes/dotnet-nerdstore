using Microsoft.Extensions.Options;
using NerdStore.Enterprise.Core.Communication;
using NerdStore.Enterprise.Web.Extensions;
using NerdStore.Enterprise.Web.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Web.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient httpClient;

        public AutenticacaoService(HttpClient httpClient, IOptions<AppSettings> options)
        {
            httpClient.BaseAddress = new Uri(options.Value.AutenticacaoUrl);
            this.httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);
            var response = await httpClient.PostAsync("/api/identidade/auntenticar", loginContent);

            if (!TratarErrosResponse(response))
                return new UsuarioRespostaLogin { ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response) };

            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var usuarioContent = ObterConteudo(usuarioRegistro);
            var response = await httpClient.PostAsync("/api/identidade/nova-conta", usuarioContent);

            if (!TratarErrosResponse(response))
                return new UsuarioRespostaLogin { ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response) };

            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }
    }
}
