using System.Threading.Tasks;
using Solicitacao.Aplicacao;
using Solicitacao.Dominio.SolicitacoesDeManutencao;
using Solicitacao.Dominio.Subsidiarias;
using Microsoft.EntityFrameworkCore;

namespace Solicitacao.Infra.BancoDeDados.Contexto
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<SolicitacaoDeManutencao> SolicitacaoesDeManutencao { get; set; }
        public DbSet<Subsidiaria> Subsidiarias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SolicitacaoDeManutencao>()
                .ToTable("SolicitacaoDeManutecao");
            modelBuilder.Entity<SolicitacaoDeManutencao>()
                .OwnsOne(p => p.Solicitante);
            modelBuilder.Entity<SolicitacaoDeManutencao>()
                .OwnsOne(p => p.Aprovador);
            modelBuilder.Entity<SolicitacaoDeManutencao>()
                .OwnsOne(p => p.Contrato);
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
