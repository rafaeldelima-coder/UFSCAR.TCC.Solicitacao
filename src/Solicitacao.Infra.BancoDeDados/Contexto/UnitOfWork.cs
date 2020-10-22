using System.Threading.Tasks;
using Solicitacao.Aplicacao;

namespace Solicitacao.Infra.BancoDeDados.Contexto
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
