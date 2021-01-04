using System.Collections.Generic;

namespace FundosInvestimentos.Models
{
    public class TipoInstituicao : BaseModel
    {
        public TipoInstituicao()
        {

        }
        public TipoInstituicao(string tipo)
        {
            this.tipo = tipo;

        }
        public string tipo { get; set; }
        public IEnumerable<Instituicao> Instituicao { get; set; }
    }
}