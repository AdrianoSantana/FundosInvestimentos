using System;
using System.Collections.Generic;

namespace FundosInvestimentos.Models
{
    public class TipoInstituicao
    {
        public TipoInstituicao()
        {

        }
        public TipoInstituicao(Guid id, string tipo, DateTime createdAt)
        {
            this.Id = id;
            this.CreatedAt = createdAt;
            this.Tipo = tipo;

        }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Tipo { get; set; }
        public IEnumerable<Instituicao> Instituicao { get; set; }
    }
}