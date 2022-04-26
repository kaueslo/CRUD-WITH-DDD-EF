using Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Clientes
{
    public interface IClienteRepositorio
    {
        #region Métodos

        Task<Cliente> ObterPorId(int idCliente);

        Task<Cliente> Inserir(Cliente objeto);

        Task<Cliente> Atualizar(Cliente objeto);

        Task<bool> Deletar(Cliente objeto);

        Task<List<Cliente>> Listar();

        #endregion Métodos

    }
}
