using ExpectedObjects;
using Solicitacao.Manutencao.Teste.Util;
using Solicitacao.Manutencao.Dominio.Subisidiarias;
using Xunit;

namespace Solicitacao.Manutencao.Teste.Dominio.Subsidiarias
{
    public class SubsidiariaTeste
    {
        [Fact]
        public void Deve_criar_subsidiaria()
        {
            var subsidiaraEsperada = new
            {
                Nome = "São Carlos"
            };

            var subsidiaria = new Subsidiaria(subsidiaraEsperada.Nome);
            subsidiaraEsperada.ToExpectedObject().ShouldMatch(subsidiaria);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Deve_validar_nome(string nomeInvalido)
        {
            const string mensagemExperada = "Nome da subsidiária é inválido";
            AfirmaExtensao.VerificarMensagem(() => new Subsidiaria(nomeInvalido), mensagemExperada);
        }
    }
}
