using Solicitacao.Manutencao.Dominio;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Solicitacao.Manutencao.Teste.Util
{
    public static class AfirmaExtensao
    {
        public static void VerificarMensagem(Action testeNoCodigo, string mensagemEsperada)
        {
            var mensagem = Assert.Throws<ExcecaoDeDominio>(testeNoCodigo).Message;

            Assert.Equal(mensagemEsperada, mensagem);

        }

        public static void VerificarMensagem(Func<Task> testeNoCodigo, string mensagemEsperada)
        {
            var result = Assert.ThrowsAsync<ExcecaoDeDominio>(testeNoCodigo).Result;
            Assert.Equal(mensagemEsperada, result.Message);
        }
    }
}