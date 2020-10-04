using ExpectedObjects;
using Solicitacao.Manutencao.Dominio.SolicitacoesDeManutencao;
using Solicitacao.Manutencao.Teste.Util;
using Xunit;

namespace Solicitacao.Manutencao.Teste.Dominio.SolcitacoesDeManutencao
{

    public class SolicitanteTeste
    {
        private const int Identificador = 128;
        private const string Nome = "Delano Medeiros";

        [Fact]
        public void Deve_criar_solicitante() 
        {
            var solicitateTeste = new
            {
                Identificador,
                Nome
            };

            var solicitante = new Solicitante(solicitateTeste.Identificador,solicitateTeste.Nome);
            solicitateTeste.ToExpectedObject().ShouldMatch(solicitante);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Deve_validar_nome_do_solicitante(string nomeInvalido)
        {
            const string mensagemTeste = "Nome do solicitante é inválido";
            AfirmaExtensao.VerificarMensagem(()=> new Solicitante(Identificador,nomeInvalido),mensagemTeste);
        }
    }
}
