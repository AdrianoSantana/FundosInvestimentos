using System.Collections.Generic;

namespace FundosInvestimentos.Models
{
    public class FundoDistribuido
    {
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }

        public IEnumerable<FundoFundosDistribuidos> FundoFundosDistribuidos { get; set; }
    }
}