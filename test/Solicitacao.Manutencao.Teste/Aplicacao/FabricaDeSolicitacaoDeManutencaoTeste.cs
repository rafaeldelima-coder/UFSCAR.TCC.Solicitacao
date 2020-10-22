using Nosbor.FluentBuilder.Lib;
using NSubstitute;
using Solicitacao.Manutencao.Aplicacao.SolicitacoesDeManutencao;
using Solicitacao.Manutencao.Aplicacao.Subsidiarias;
using Solicitacao.Manutencao.Dominio.SolicitacoesDeManutencao;
using Solicitacao.Manutencao.Dominio.Subisidiarias;
using Solicitacao.Manutencao.Teste.Util;
using System;
using Xunit;

namespace Solicitacao.Manutencao.Teste.Aplicacao
{
    public class FabricaDeSolicitacaoDeManutencaoTeste
    {
        private readonly ContratoDto _contratoDto;
        private readonly SolicitacaoDeManutencaoDto _dto;
        private readonly Subsidiaria _subsidiaria;
        private readonly FabricaDeSolicitacaoDeManutencao _fabrica;
        private readonly ISubsidiariaRepositorio _subsidiariaRepositorio;
        private readonly IBuscadorDeContrato _buscadorDeContrato;

        public FabricaDeSolicitacaoDeManutencaoTeste()
        {
            _dto = new SolicitacaoDeManutencaoDto
            {
                SubsidiariaId = "Grma",
                SolicitanteId = 1,
                NomeDoSolicitante = "Ricardo José",
                TipoDeSolicitacaoDeManutencao = TipoDeSolicitacaoDeManutencao.Jardinagem.GetHashCode(),
                Justificativa = "Grama Alta",
                NumeroDoContrato = "2135",
                InicioDesejadoParaManutencao = DateTime.Now.AddMonths(2)
            };
            _contratoDto = new ContratoDto
            {
                Numero = _dto.NumeroDoContrato,
                NomeDaTerceirizada = "Grama SA",
                GestorDoContrato = "Rafael Lima",
                CnpjDaTerceirizada = "00000000000000",
                DataFinalDaVigencia = DateTime.Now.AddMonths(1)
            };

            _subsidiariaRepositorio = Substitute.For<ISubsidiariaRepositorio>();
            _subsidiaria = FluentBuilder<Subsidiaria>.New().With(s => s.Id, _dto.SubsidiariaId).Build();
            _subsidiariaRepositorio.ObterPorId(_dto.SubsidiariaId).Returns(_subsidiaria);
            _buscadorDeContrato = Substitute.For<IBuscadorDeContrato>();
            _buscadorDeContrato.Buscar(_dto.NumeroDoContrato).Returns(_contratoDto);
            _fabrica = new FabricaDeSolicitacaoDeManutencao(_subsidiariaRepositorio, _buscadorDeContrato);

        }

        [Fact]
        public void Deve_solicitacao_criada_ter_informacoes_do_contrato_buscado()
        {
            var solicitacaoCriada = _fabrica.Fabricar(_dto);

            Assert.Equal(solicitacaoCriada.Contrato.Numero, _contratoDto.Numero);
        }

        [Fact]
        public void Deve_validar_contrato_quando_nao_encontrado_no_erp()
        {
            const string mensagemEsperada = "Contrato não encontrado no ERP";
            _buscadorDeContrato.Buscar(_dto.NumeroDoContrato).Returns((ContratoDto)null);

            AfirmaExtensao.VerificarMensagem(() => _fabrica.Fabricar(_dto), mensagemEsperada);
        }

        [Fact]
        public void Deve_solicitacao_criada_ter_subsidiaria()
        {
            var solicitacaoCriada = _fabrica.Fabricar(_dto);

            Assert.Equal(solicitacaoCriada.IdentificadorDaSubsidiaria, _subsidiaria.Id);
        }

        [Fact]
        public void Deve_validar_subsidiaria_quando_nao_encontrada()
        {
            const string mensagemEsperada = "Subsidiária não encontrada";
            _subsidiariaRepositorio.ObterPorId(_dto.SubsidiariaId).Returns((Subsidiaria)null);

            AfirmaExtensao.VerificarMensagem(() => _fabrica.Fabricar(_dto), mensagemEsperada);
        }
    }
}