using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Repositorios;

namespace Repositorio.EntityConfig
{
    public class ClienteConfig
    {
        #region Construtores

        public ClienteConfig(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.idCliente);

            builder.Property(c => c.nomeCliente)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.sobrenomeCliente)
                .IsRequired()
                .HasMaxLength(50);
        }

        #endregion
    }
}
