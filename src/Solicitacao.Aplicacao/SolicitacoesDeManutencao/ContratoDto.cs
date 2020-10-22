using System;

namespace Solicitacao.Aplicacao.SolicitacoesDeManutencao
{
    public class ContratoDto
    {
        public string Numero { get; set; }
        public string NomeDaTerceirizada { get; set; }
        public string CnpjDaTerceirizada { get; set; }
        public string GestorDoContrato { get; set; }
        public DateTime DataFinalDaVigencia { get; set; }
    }
}
