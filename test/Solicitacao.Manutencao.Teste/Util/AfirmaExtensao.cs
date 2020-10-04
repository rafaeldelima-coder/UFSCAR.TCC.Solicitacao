using Solicitacao.Manutencao.Dominio;
using System;
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
    }
}