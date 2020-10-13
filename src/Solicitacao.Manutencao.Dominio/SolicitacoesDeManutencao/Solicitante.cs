using System;
using System.Collections.Generic;
using System.Text;

namespace Solicitacao.Manutencao.Dominio.SolicitacoesDeManutencao
{
    public class Solicitante:Autor
    {
        public Solicitante(int identificador, string nome):base(identificador,nome)
        {
            ExcecaoDeDominio.LancarQuando(string.IsNullOrEmpty(nome), "Nome do solicitante é inválido");

        }
    }
}