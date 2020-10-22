using System.Collections.Generic;

namespace Solicitacao.Dominio.SolicitacoesDeManutencao
{
    public interface ICanceladorDeSolicitacoesDeManutencaoPendentes
    {
        void Cancelar(IEnumerable<SolicitacaoDeManutencao> solicitacoesDeManutencaoPendentes);
    }
}