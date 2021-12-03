using NerdStore.Enterprise.Web.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Web.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent(JsonSerializer.Serialize(usuarioLogin), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44333/api/identidade/auntenticar", loginContent);
            
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var usuarioContent = new StringContent(JsonSerializer.Serialize(usuarioRegistro), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44333/api/identidade/nova-conta", usuarioContent);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}
