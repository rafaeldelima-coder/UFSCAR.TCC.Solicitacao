using System;
using System.Collections.Generic;
using System.Text;

namespace Solicitacao.Manutencao.Aplicacao
{
    public interface IRepositorio<TEntidade>
    {
        List<TEntidade> Consultar();
        TEntidade ObterPorId(string id);
        void Adicionar(TEntidade entidade);
    }
}
