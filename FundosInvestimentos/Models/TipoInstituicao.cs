using System.Collections.Generic;

namespace FundosInvestimentos.Models
{
    public class TipoInstituicao : BaseModel
    {
        public string tipo { get; set; }
        public IEnumerable<Instituicao> Instituicao { get; set; }
    }
}