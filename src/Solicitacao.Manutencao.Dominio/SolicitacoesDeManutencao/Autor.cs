using System;
using System.Collections.Generic;
using System.Text;

namespace Solicitacao.Manutencao.Dominio.SolicitacoesDeManutencao
{
    public  class Autor
    {
        public int Identificador { get; private set; }
        public string Nome { get; private set; }

        private Autor() { }

        public Autor(int identificador, string nome)
        {
            ExcecaoDeDominio.LancarQuando(string.IsNullOrEmpty(nome), "Nome do autor é inválido");

            Identificador = identificador;
            Nome = nome;
        }
    }
}
