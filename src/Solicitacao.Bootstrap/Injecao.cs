using Solicitacao.Aplicacao;
using Solicitacao.Aplicacao.SolicitacoesDeManutencao;
using Solicitacao.Aplicacao.Subsidiarias;
using Solicitacao.Dominio.SolicitacoesDeManutencao;
using Solicitacao.Infra.BancoDeDados.Contexto;
using Solicitacao.Infra.BancoDeDados.Repositorio;
using Solicitacao.Infra.ContextoDeServico;
using Solicitacao.Infra.Email;
using Solicitacao.Infra.ErpContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Solicitacao.Bootstrap
{
    public static class Injecao 
    {
        public static void Inicializar(IServiceCollection services, string conexaoDoBancoDeDados)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(conexaoDoBancoDeDados));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISolicitacaoDeManutencaoRepositorio, 
                SolicitacaoDeManutencaoRepositorio>();
            services.AddScoped<ISubsidiariaRepositorio, SubsidiariaRepositorio>();
            services.AddScoped<IBuscadorDeContrato>(buscador => 
                new BuscadorDeContrato("http://localhost:3000/contracts"));
            services.AddScoped<INotificaContextoDeServico>(buscador =>
                new NotificaContextoDeServico("http://localhost:3000/servico"));
            services.AddScoped<INotificaReprovacaoParaSolicitante,
                NotificaReprovacaoParaSolicitante>();
            services.AddScoped<ICanceladorDeSolicitacoesDeManutencaoPendentes, 
                CanceladorDeSolicitacoesDeManutencaoPendentes>();
            services.AddScoped<SolicitadorDeManutencao, SolicitadorDeManutencao>();
            services.AddScoped<FabricaDeSolicitacaoDeManutencao, FabricaDeSolicitacaoDeManutencao>();
            services.AddScoped<AnaliseDeAprovacaoDaSolicitacaoDeManutencao, AnaliseDeAprovacaoDaSolicitacaoDeManutencao>();
        }
    }
}
