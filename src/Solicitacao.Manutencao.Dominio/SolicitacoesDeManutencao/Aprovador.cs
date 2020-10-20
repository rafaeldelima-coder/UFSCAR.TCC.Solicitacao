﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Solicitacao.Manutencao.Dominio.SolicitacoesDeManutencao
{
    public class Aprovador:Autor
    {
        public Aprovador(int identificador,string nome ) : base(identificador, nome)
        {
            ExcecaoDeDominio.LancarQuando(string.IsNullOrEmpty(nome), "Nome do aprovador é inválido");
        }
    }
}
