using Nosbor.FluentBuilder.Lib;
using NSubstitute;
using Solicitacao.Manutencao.Aplicacao.SolicitacaoDeManutencaoRepositorio;
using Solicitacao.Manutencao.Aplicacao.Subsidiarias;
using Solicitacao.Manutencao.Dominio.SolicitacoesDeManutencao;
using Solicitacao.Manutencao.Dominio.Subisidiarias;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Solicitacao.Manutencao.Teste.Aplicacao
{
    public class SolicitadorDeManutencaoTeste
    {
        private readonly SolicitacaoDeManutencaoDto _dto;
        private readonly SolicitadorDeManutencao _solicitador;
        private readonly ISolicitacaoDeManutencaoRepositorio _solicitacaoDeManutencaoRepositorio;
        private readonly Subsidiaria _subsidiaria;

        public SolicitadorDeManutencaoTeste() 
        {
            _dto = new SolicitacaoDeManutencaoDto
            {
                SubsidiariaId = "Teste",
                SolicitanteId = 1,
                NomeDoSolicitante = "Rafael Lima",
                TipoDeSolicitacaoDeManutencao = TipoDeSolicitacaoDeManutencao.Jardinagem.GetHashCode(),
                Justificativa = "Grama Alta",
                NumeroDoContrato = "142",
                InicioDesejadoParaManutencao = DateTime.Now.AddDays(15)
            };
            _solicitacaoDeManutencaoRepositorio = Substitute.For<ISolicitacaoDeManutencaoRepositorio>();
            var subsidiariaRepositorio = Substitute.For<ISubsidiariaRepositorio>();
            _subsidiaria = FluentBuilder<Subsidiaria>.New().Build();
            subsidiariaRepositorio.ObterPorId(_dto.SubsidiariaId).Returns(_subsidiaria);
            _solicitador = new SolicitadorDeManutencao(_solicitacaoDeManutencaoRepositorio,subsidiariaRepositorio);
        }

        [Fact]
        public void Deve_salvar_solcitacao_de_manutencao()
        {
            _solicitador.Solicitar(_dto);

            _solicitacaoDeManutencaoRepositorio.Received(1)
                .Adicionar(Arg.Is<SolicitacaoDeManutencao>(solicitacao =>
                solicitacao.Solicitante.Identificador == _dto.SolicitanteId));
        }
        [Fact]

    }
}
