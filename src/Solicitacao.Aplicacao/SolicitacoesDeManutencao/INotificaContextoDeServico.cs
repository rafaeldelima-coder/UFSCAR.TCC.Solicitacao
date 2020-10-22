using System.Threading.Tasks;
using Solicitacao.Dominio.SolicitacoesDeManutencao;

namespace Solicitacao.Aplicacao.SolicitacoesDeManutencao
{
    public interface INotificaContextoDeServico
    {
        Task Notificar(SolicitacaoDeManutencao solicitacaoDeManutencao);
    }
}
