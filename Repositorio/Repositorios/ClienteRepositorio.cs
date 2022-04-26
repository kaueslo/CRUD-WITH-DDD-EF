using AutoMapper;
using Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class ClienteRepository : BaseRepositorio, IClienteRepositorio
    {
        #region Construtores

        public ClienteRepository(AplicacaoDBContext contexto, ILogger logger, IMapper mapper) : base(contexto, logger, mapper)
        {

        }

        #endregion Construtores

        #region Metodos

        public async Task<Cliente> ObterPorId(int idCliente)
        {
            try
            {
                return await _contexto.cliente.FirstOrDefaultAsync(x => x.idCliente == idCliente);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> Inserir(Cliente objeto)
        {
            try
            {
                await _contexto.cliente.AddAsync(objeto);

                await _contexto.SaveChangesAsync();

                return objeto;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> Atualizar(Cliente objeto)
        {
            try
            {
                _contexto.cliente.Update(objeto);

                await _contexto.SaveChangesAsync();

                return objeto;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Deletar(Cliente objeto)
        {
            try
            {
                _contexto.cliente.Remove(objeto);

                await _contexto.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "ClienteRepositorio - Deletar");

                return false;
            }
        }

        public async Task<List<Cliente>> Listar()
            => await _contexto.cliente.OrderByDescending(x => x.idCliente).ToListAsync();

        #endregion
    }
}
