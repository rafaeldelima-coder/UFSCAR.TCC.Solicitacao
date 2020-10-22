using System.Threading.Tasks;

namespace Solicitacao.Aplicacao.SolicitacoesDeManutencao
{
    public interface IBuscadorDeContrato
    {
        Task<ContratoDto> Buscar(string numero);
    }
}
