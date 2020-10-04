using System;
using System.Collections.Generic;
using System.Text;

namespace Solicitacao.Manutencao.Dominio.Subisidiarias
{
    public class Subsidiaria
    {
        public string Nome { get; private set; }
        public Subsidiaria(string nome) 
        {
            ExcecaoDeDominio.LancarQuando(string.IsNullOrEmpty(nome), "Nome da subsidiária é inválido");
            Nome = nome;
        }
    }
}
