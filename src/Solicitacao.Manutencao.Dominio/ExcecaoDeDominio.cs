using System;
using System.Collections.Generic;
using System.Text;

namespace Solicitacao.Manutencao.Dominio
{
    public class ExcecaoDeDominio:Exception
    {
        public ExcecaoDeDominio(string mensagem) : base(mensagem) { }

        public static void LancarQuando(bool regraIvalida, string mensagem)
        {
            if (regraIvalida)
                throw new ExcecaoDeDominio(mensagem);
        }
    }
}
