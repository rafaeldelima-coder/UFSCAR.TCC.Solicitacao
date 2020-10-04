using Solicitacao.Manutencao.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Solicitacao.Manutencao.Testes.Util
{
   public static class AfirmarExtensao
    {
        public static void VerificarMensagem(Action testeNoCodigo, string mensagemEsperada)
        {
            var mensagem = Assert.Throws<ExcecaoDeDominio>(testeNoCodigo).Message;

            Assert.Equal(mensagemEsperada, mensagem);
            
        }
    }
}
