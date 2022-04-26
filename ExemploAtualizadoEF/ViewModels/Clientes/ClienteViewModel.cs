using System.Collections.Generic;

namespace ExemploAtualizadoEF.ViewModels.Clientes
{
    public class ClienteViewModel
    {
        #region Propriedades

        public int idCliente { get; set; }

        public string nomeCliente { get; set; }

        public string sobrenomeCliente { get; set; }

        public List<ClienteViewModel> clientes { get; set; }

        #endregion Propriedades

    }
}
