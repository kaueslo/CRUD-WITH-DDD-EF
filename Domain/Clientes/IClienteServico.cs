using Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Clientes
{
    public interface IClienteServico
    {
        Task<Cliente> ObterPorId(int idCliente);

        Task<Cliente> InserirAtualizar(Cliente objeto);

        Task<bool> Deletar(Cliente objeto);

        Task<List<Cliente>> Listar();
    }
}
