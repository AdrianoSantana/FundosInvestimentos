using System;
using System.Collections.Generic;

namespace FundosInvestimentos.Models
{
    public class Instituicao : BaseModel
    {
        public Instituicao()
        {

        }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public TipoInstituicao TipoInstituicao { get; set; }
        public Guid TipoInstituicaoId { get; set; }
        public IEnumerable<Fundo> Fundos { get; set; }

    }
}