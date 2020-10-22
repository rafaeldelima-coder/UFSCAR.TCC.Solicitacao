using System.Threading.Tasks;

namespace Solicitacao.Aplicacao
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
