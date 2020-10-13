using ExpectedObjects;
using Solicitacao.Manutencao.Dominio.SolicitacoesDeManutencao;
using Solicitacao.Manutencao.Teste.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Solicitacao.Manutencao.Teste.Dominio.SolicitacoesDeManutencao
{
    public class AutorTeste
    {
        private const int Identificador = 128;
        private const string Nome = "Delano Medeiros";

        [Fact]
        public void Deve_criar_autor()
        {
            var AutorTeste = new
            {
                Identificador,
                Nome
            };

            var autor = new Autor(AutorTeste.Identificador, AutorTeste.Nome);
            AutorTeste.ToExpectedObject().ShouldMatch(autor);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Deve_validar_nome_do_aprovador(string nomeInvalido)
        {
            const string mensagemTeste = "Nome do autor é inválido";
            AfirmaExtensao.VerificarMensagem(() => new Aprovador(nomeInvalido, Identificador), mensagemTeste);
        }
    }
}
