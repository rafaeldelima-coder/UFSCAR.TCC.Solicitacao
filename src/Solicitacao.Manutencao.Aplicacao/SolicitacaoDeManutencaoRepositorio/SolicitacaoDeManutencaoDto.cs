using System;
using System.Collections.Generic;
using System.Text;

namespace Solicitacao.Manutencao.Aplicacao.SolicitacaoDeManutencaoRepositorio
{
    public class SolicitacaoDeManutencaoDto
    {
        public string SubsidiariaId { get; set; }
        public int SolicitanteId { get; set; }
        public string NomeDoSolicitante { get; set; }
        public int TipoDeSolicitacaoDeManutencao { get; set; }
        public string Justificativa { get; set; }
        public string NumeroDoContrato { get; set; }
        public DateTime InicioDesejadoParaManutencao { get; set; }
    }
}
