using AutoMapper;
using Domain.Clientes;
using Microsoft.Extensions.Logging;
using Repositorio;
using Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servico
{
    public class ClienteServico : BaseRepositorio, IClienteServico
    {
        #region Propriedades

        private readonly IClienteRepositorio _clienteRepositorio;

        #endregion Propriedades

        #region Construtores

        public ClienteServico(AplicacaoDBContext aplicacaoDBContext, ILogger logger, IMapper mapper,IClienteRepositorio clienteRepositorio) : base(aplicacaoDBContext, logger, mapper)
        {
            _clienteRepositorio = clienteRepositorio ?? throw new ArgumentNullException(nameof(clienteRepositorio));
        }

        #endregion Construtores

        #region Métodos

        public async Task<Cliente> ObterPorId(int idCliente)
        {
            try
            {
                Cliente retorno = await _clienteRepositorio.ObterPorId(idCliente);

                return retorno;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> InserirAtualizar(Cliente objeto)
        {
            try
            {
                Cliente obj = await ObterPorId(objeto.idCliente);
                Cliente Retorno = new Cliente();

                if (obj != null)
                {
                    Retorno = await _clienteRepositorio.Atualizar(obj);
                }
                else
                {
                    Retorno = await _clienteRepositorio.Inserir(obj);
                }

                return Retorno;
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
                await _clienteRepositorio.Deletar(objeto);

                return true;

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "ClienteServico - Deletar");

                return false;
            }
        }

        public async Task<List<Cliente>> Listar()
        {
            try
            {
                List<Cliente> retorno = await _clienteRepositorio.Listar();

                retorno.OrderByDescending(x => x.idCliente);

                return retorno;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion Métodos

    }
}
