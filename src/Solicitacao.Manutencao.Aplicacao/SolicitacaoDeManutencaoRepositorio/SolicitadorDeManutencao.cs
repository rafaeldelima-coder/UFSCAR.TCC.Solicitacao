using Solicitacao.Manutencao.Aplicacao.Subsidiarias;
using Solicitacao.Manutencao.Dominio.SolicitacoesDeManutencao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solicitacao.Manutencao.Aplicacao.SolicitacaoDeManutencaoRepositorio
{
    public class SolicitadorDeManutencao
    {
        private readonly ISolicitacaoDeManutencaoRepositorio _solicitacaoDeManutencaoRepositorio;
        private readonly ISubsidiariaRepositorio _subsidiariaRepositorio;

        public SolicitadorDeManutencao(ISolicitacaoDeManutencaoRepositorio solicitacaoDeManutencaoRepositorio,
            ISubsidiariaRepositorio subsidiariaRepositorio)
        {
            _solicitacaoDeManutencaoRepositorio = solicitacaoDeManutencaoRepositorio;
            _subsidiariaRepositorio = subsidiariaRepositorio;
        }

        public void Solicitar(SolicitacaoDeManutencaoDto dto)
        {
            var subsidiaria = _subsidiariaRepositorio.ObterPorId(dto.SubsidiariaId);
            var tipoDeSolicitacaoDeManutencao = Enum.Parse<TipoDeSolicitacaoDeManutencao>(dto.TipoDeSolicitacaoDeManutencao.ToString());
            var solicitacaoDeManutencao =
                new SolicitacaoDeManutencao(
                subsidiaria,
                dto.SolicitanteId,
                dto.NomeDoSolicitante,
                tipoDeSolicitacaoDeManutencao,
                dto.Justificativa,
                dto.NumeroDoContrato,
                "Jardinagem SA",
                "00000000000000",
                "Rafael Perez",
                DateTime.Now.AddDays(90),
                dto.InicioDesejadoParaManutencao
                );
            _solicitacaoDeManutencaoRepositorio.Adicionar(solicitacaoDeManutencao);
        }
    }
}
