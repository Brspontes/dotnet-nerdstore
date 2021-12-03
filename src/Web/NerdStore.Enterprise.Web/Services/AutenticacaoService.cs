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

        public async Task<string> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent(JsonSerializer.Serialize(usuarioLogin), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44333/api/identidade/auntenticar", loginContent);
            
            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Registro(UsuarioRegistro usuarioRegistro)
        {
            var usuarioContent = new StringContent(JsonSerializer.Serialize(usuarioRegistro), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44333/api/identidade/nova-conta", usuarioContent);

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }
    }
}
