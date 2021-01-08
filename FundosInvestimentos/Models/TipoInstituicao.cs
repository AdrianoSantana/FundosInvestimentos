using System;
using System.Collections.Generic;

namespace FundosInvestimentos.Models
{
    public class TipoInstituicao : BaseModel
    {
        public TipoInstituicao()
        {

        }
        public TipoInstituicao(Guid id, string tipo, DateTime createdAt) : base(id, createdAt, createdAt)
        {
            this.Tipo = tipo;

        }
        public string Tipo { get; set; }
        public IEnumerable<Instituicao> Instituicao { get; set; }
    }
}