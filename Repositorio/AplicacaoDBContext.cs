using Microsoft.EntityFrameworkCore;
using Repositorio.EntityConfig;
using Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio
{
    public class AplicacaoDBContext : DbContext
    {
        #region Propriedades

        public DbSet<Cliente> cliente { get; set; }

        #endregion

        #region Construtores
        public AplicacaoDBContext(DbContextOptions<AplicacaoDBContext> options) : base(options)
        {

        }
        #endregion

        #region Metodos

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AplicacaoDBContext).Assembly);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(builder);

            new ClienteConfig(builder.Entity<Cliente>());
        }

            #endregion
        }
}
