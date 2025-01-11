using GerenciadorUsuarios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace GerenciadorUsuarios.Infraestrutura.Contextos
{
    public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
    {
        #region DbSets
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<UsuarioPerfil> UsuariosPerfis { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("ConexaoPadrao");

                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }



    }

}
