using Solicitacao.Aplicacao.Subsidiarias;
using Solicitacao.Dominio.Subsidiarias;
using Solicitacao.Infra.BancoDeDados.Contexto;

namespace Solicitacao.Infra.BancoDeDados.Repositorio
{
    public class SubsidiariaRepositorio : RepositorioBase<Subsidiaria>, ISubsidiariaRepositorio
    {
        public SubsidiariaRepositorio(ApplicationDbContext context) : base(context)
        {
        }
    }
}
