using System;
using System.Collections.Generic;
using System.Text;

namespace Solicitacao.Manutencao.Dominio.SolicitacoesDeManutencao
{
    public class SolicitacaoDeManutencao:Entidade
    {
        public  Solicitante Solicitante { get; private set; }
        public Aprovador Aprovador { get; private set; }
    }
}
