using NerdStore.Enterprise.Web.Models;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Web.Services
{
    public interface IAutenticacaoService
    {
        Task<string> Login(UsuarioLogin usuarioLogin);
        Task<string> Registro(UsuarioRegistro usuarioRegistro);
    }
}
