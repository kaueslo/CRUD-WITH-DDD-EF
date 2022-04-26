using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorios
{
    public class BaseRepositorio
    {
        #region Propriedades

        public readonly AplicacaoDBContext _contexto;

        public readonly ILogger _logger;

        public readonly IMapper _mapper;

        #endregion

        #region Construtores
        public BaseRepositorio(AplicacaoDBContext contexto, ILogger logger, IMapper mapper)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion
    }
}
