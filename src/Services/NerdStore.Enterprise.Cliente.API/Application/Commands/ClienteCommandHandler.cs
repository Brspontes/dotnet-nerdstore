using FluentValidation.Results;
using MediatR;
using NerdStore.Enterprise.Cliente.API.Models;
using NerdStore.Enterprise.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Cliente.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteCommandHandler(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var cliente = new NerdStore.Enterprise.Cliente.API.Models.Cliente(message.Id, message.Nome, message.Email, message.Cpf);

            var clienteExistente = await clienteRepository.ObterPorCpf(cliente.Cpf.Numero);

            if (clienteExistente != null)
            {
                AdicionarErro("Este CPF já está em uso");
                return ValidationResult;
            }

            clienteRepository.Adicionar(cliente);

            return await PersistirDados(clienteRepository.UnitOfWork);
        }
    }
}
