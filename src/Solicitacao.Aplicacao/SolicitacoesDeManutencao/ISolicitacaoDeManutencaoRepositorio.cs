using System.Collections.Generic;
using Solicitacao.Dominio.SolicitacoesDeManutencao;

namespace Solicitacao.Aplicacao.SolicitacoesDeManutencao
{
    public interface ISolicitacaoDeManutencaoRepositorio : IRepositorio<SolicitacaoDeManutencao>
    {
        IEnumerable<SolicitacaoDeManutencao> ObterPendentesDoTipo(
            TipoDeSolicitacaoDeManutencao tipo, string identificadorDaSubsidiaria);
        IEnumerable<SolicitacaoDeManutencao> ObterPendentesDa(string identificadorDaSubsidiaria);
    }
}