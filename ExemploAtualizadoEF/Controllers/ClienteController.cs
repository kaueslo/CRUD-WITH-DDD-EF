using AutoMapper;
using Domain.Clientes;
using ExemploAtualizadoEF.ViewModels.Clientes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploAtualizadoEF.Controllers
{
    public class ClienteController : Controller
    {
        #region Propriedades

        private readonly IClienteServico _clienteServico;

        private readonly IMapper _mapper;

        #endregion Propriedades

        #region Construtores

        public ClienteController(IClienteServico clienteServico, IMapper mapper)
        {
            _clienteServico = clienteServico ?? throw new ArgumentNullException(nameof(clienteServico));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Construtores

        #region Métodos

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ClienteViewModel model = new ClienteViewModel();

            try
            {
                List<Cliente> clientes = await _clienteServico.Listar();

                if (clientes != null)
                {
                    model.clientes = _mapper.Map<List<ClienteViewModel>>(clientes);
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult InserirAtualizarCliente()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> InserirAtualizarCliente(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _clienteServico.InserirAtualizar(cliente);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(cliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult ExcluirCliente(int idCliente)
        {
            ClienteViewModel clienteViewModel = new ClienteViewModel();

            if(idCliente != 0)
            {
                Task<Cliente> cliente = _clienteServico.ObterPorId(idCliente);

                if(cliente != null)
                {
                    clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);
                }

                return View(clienteViewModel);                
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]

        public async Task<IActionResult> ExcluirCliente(ClienteViewModel cliente)
        {
            try
            {
                Cliente objeto = new Cliente();

                if (cliente != null)
                {
                    objeto = _mapper.Map<Cliente>(cliente);

                    await _clienteServico.Deletar(objeto);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion Métodos

    }
}
