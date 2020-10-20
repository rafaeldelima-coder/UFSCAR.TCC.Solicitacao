using ExpectedObjects;
using Solicitacao.Manutencao.Dominio.SolicitacoesDeManutencao;
using Solicitacao.Manutencao.Teste.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Solicitacao.Manutencao.Teste.Dominio.SolicitacoesDeManutencao
{
    public  class AprovadorTeste
    {
        private const int Identificador = 128;
        private const string Nome = "Delano Medeiros";

        [Fact]
        public void Deve_criar_aprovador()
        {
            var aprovadorTeste = new
            {
                Identificador,
                Nome
            };

            var aprovador = new Aprovador(aprovadorTeste.Identificador, aprovadorTeste.Nome);
            aprovadorTeste.ToExpectedObject().ShouldMatch(aprovador);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Deve_validar_nome_do_aprovador(string nomeInvalido)
        {
            const string mensagemTeste = "Nome do aprovador é inválido";
            AfirmaExtensao.VerificarMensagem(() => new Aprovador( Identificador,nomeInvalido), mensagemTeste);
        }
    }
}
