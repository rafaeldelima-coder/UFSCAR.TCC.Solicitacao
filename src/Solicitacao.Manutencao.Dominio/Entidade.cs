using System;
using System.Collections.Generic;
using System.Text;

namespace Solicitacao.Manutencao.Dominio
{
    public abstract class Entidade
    {
        public string Id { get; set; }

        protected Entidade()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}