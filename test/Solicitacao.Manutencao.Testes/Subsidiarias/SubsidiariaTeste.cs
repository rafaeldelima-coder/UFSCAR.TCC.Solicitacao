using ExpectedObjects;
using Solicitacao.Manutencao.Dominio.Subisidiarias;
using Solicitacao.Manutencao.Testes.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace Solicitacao.Manutencao.Testes.Subsidiarias
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
            AfirmarExtensao.VerificarMensagem(()=> new Subsidiaria(nomeInvalido), mensagemExperada);
        }
    }
}
