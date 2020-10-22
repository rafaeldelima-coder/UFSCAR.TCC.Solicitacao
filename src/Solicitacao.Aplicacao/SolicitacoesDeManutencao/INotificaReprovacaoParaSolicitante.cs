using Solicitacao.Dominio.SolicitacoesDeManutencao;

namespace Solicitacao.Aplicacao.SolicitacoesDeManutencao
{
    public interface INotificaReprovacaoParaSolicitante
    {
        void Notificar(SolicitacaoDeManutencao solicitacaoDeManutencao);
    }
}
