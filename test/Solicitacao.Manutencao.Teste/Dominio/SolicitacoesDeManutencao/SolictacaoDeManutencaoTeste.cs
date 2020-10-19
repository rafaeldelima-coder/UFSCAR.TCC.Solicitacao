using ExpectedObjects;
using Nosbor.FluentBuilder.Lib;
using Solicitacao.Manutencao.Dominio.SolicitacoesDeManutencao;
using Solicitacao.Manutencao.Teste.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Solicitacao.Manutencao.Teste.Dominio.SolicitacoesDeManutencao
{
    public class SolictacaoDeManutencaoTeste
    {
        private const int IdentificadorDoSolicitante = 5;
        private const string NomeDoSolicitante = "Marilde Santos";
        private const string NumeroDoContrato = "9826026025118073";
        private const string NomeDaTerceirizadaDoContrato = "NUJ";
        private const string CnpjDaTerceirizadaDoContrato = "45358058000140";
        private const string GestorDoContrato = "WANDA HOFFMANN";
        private readonly DateTime _dataFinalDaVigenciaDoContrato = DateTime.Now.AddMonths(3);
        private readonly TipoDeSolicitacaoDeManutencao _tipoDeSolicitacaoDeManutencao = TipoDeSolicitacaoDeManutencao.Jardinagem;
        private string _identificadorDaSubsidiaria = "Polo Itapevi";
        private string _justificativa = "Grama muito alta";
        private DateTime _inicioDesejadoParaManutencao = DateTime.Now.AddDays(10);

        private SolicitacaoDeManutencao CriarNovaSolicitacao()
        {
            return new SolicitacaoDeManutencao(
                _identificadorDaSubsidiaria,
                IdentificadorDoSolicitante,
                NomeDoSolicitante,
                _tipoDeSolicitacaoDeManutencao,
                _justificativa,
                NumeroDoContrato,
                NomeDaTerceirizadaDoContrato,
                CnpjDaTerceirizadaDoContrato,
                GestorDoContrato,
                _dataFinalDaVigenciaDoContrato,
                _inicioDesejadoParaManutencao);
        }
        [Fact]
        public void Deve_criar_solicitacao_de_manutencao()
        {
            var solicitacao = new
            {
                IdentificadorDaSubsidiaria = _identificadorDaSubsidiaria,
                Solicitante = new Autor(IdentificadorDoSolicitante, NomeDoSolicitante),
                TipoDeSolicitacaoDeManutencao = _tipoDeSolicitacaoDeManutencao,
                Justificativa = _justificativa,
                Contrato = new Contrato(NumeroDoContrato, NomeDaTerceirizadaDoContrato, CnpjDaTerceirizadaDoContrato, GestorDoContrato, _dataFinalDaVigenciaDoContrato),
                InicioDesejadoParaManutencao = _inicioDesejadoParaManutencao
            };

            var solicitacaoDeManutencao = CriarNovaSolicitacao();

            solicitacao.ToExpectedObject().ShouldMatch(solicitacaoDeManutencao);
        }

        [Fact]
        public void Deve_solicitacao_de_manutencao_ter_data_da_solicitacao_de_hoje()
        {
            var dataDaSolicitacaoEsperada = DateTime.Now;

            var solicitacaoDeManutencao = CriarNovaSolicitacao();

            Assert.Equal(dataDaSolicitacaoEsperada.Date, solicitacaoDeManutencao.DataDaSolicitacao.Date);
        }

        [Fact]
        public void Deve_solicitacao_de_manutencao_iniciar_com_status_pendente()
        {
            var statusDaSolicitacao = StatusDaSolicitacao.Pendente;

            var solicitacaoDeManutencao = CriarNovaSolicitacao();

            Assert.Equal(statusDaSolicitacao, solicitacaoDeManutencao.StatusDaSolicitacao);
        }

        [Fact]
        public void Deve_validar_subsidiaria()
        {
            const string mensagemEsperada = "Subsidiária é inválida";
            _identificadorDaSubsidiaria = null;

            AfirmaExtensao.VerificarMensagem(() => CriarNovaSolicitacao(), mensagemEsperada);
        }

        [Fact]
        public void Deve_cancelar_solicitacao_de_manutencao()
        {
            var solicitacao = FluentBuilder<SolicitacaoDeManutencao>.New().Build();

            solicitacao.Cancelar();

            Assert.Equal(StatusDaSolicitacao.Cancelada, solicitacao.StatusDaSolicitacao);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Deve_validar_justificativa(string justificativaInvalida)
        {
            const string mensagemEsperada = "Justificativa inválida";
            _justificativa = justificativaInvalida;

            AfirmaExtensao.VerificarMensagem(() => CriarNovaSolicitacao(), mensagemEsperada);
        }

        [Fact]
        public void Deve_validar_data_de_inicio_desejado_para_manutencao()
        {
            const string mensagemEsperada = "Data do inicio desejado não pode ser inferior a data de hoje";
            var dataInvalida = DateTime.Now.AddDays(-1);
            _inicioDesejadoParaManutencao = dataInvalida;


            AfirmaExtensao.VerificarMensagem(() => CriarNovaSolicitacao(), mensagemEsperada);
        }

        [Fact]
        public void Deve_reprovar_solicitacao_de_manutencao()
        {
            var aprovador = new Aprovador("Reprovador",1);
            var solicitacao = FluentBuilder<SolicitacaoDeManutencao>.New().Build();

            solicitacao.Reprovar(aprovador);

            Assert.Equal(StatusDaSolicitacao.Reprovada, solicitacao.StatusDaSolicitacao);
        }

        [Fact]
        public void Deve_informar_o_aprovador_da_reprovacao()
        {
            var aprovador = new Aprovador("Reprovador",1);
            var solicitacao = FluentBuilder<SolicitacaoDeManutencao>.New().Build();

            solicitacao.Reprovar(aprovador);

            Assert.Equal(aprovador, solicitacao.Aprovador);
        }

        [Fact]
        public void Deve_aprovar_solicitacao_de_manutencao()
        {
            var aprovador = new Aprovador("Reprovador",1);
            var solicitacao = FluentBuilder<SolicitacaoDeManutencao>.New().Build();

            solicitacao.Aprovar(aprovador);

            Assert.Equal(StatusDaSolicitacao.Aprovada, solicitacao.StatusDaSolicitacao);
        }

        [Fact]
        public void Deve_informar_o_aprovador_da_aprovacao()
        {
            var aprovador = new Aprovador("Reprovador",1);
            var solicitacao = FluentBuilder<SolicitacaoDeManutencao>.New().Build();

            solicitacao.Aprovar(aprovador);

            Assert.Equal(aprovador, solicitacao.Aprovador);
        }


    }
}
