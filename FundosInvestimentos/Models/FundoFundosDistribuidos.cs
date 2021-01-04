using System;

namespace FundosInvestimentos.Models
{
    public class FundoFundosDistribuidos
    {
        public FundoFundosDistribuidos()
        {

        }
        public FundoFundosDistribuidos(Guid fundoId, Guid fundoDistribuidoId)
        {
            this.FundoId = fundoId;
            this.FundoDistribuidoId = fundoDistribuidoId;

        }
        public Guid FundoId { get; set; }
        public Guid FundoDistribuidoId { get; set; }

        public Fundo Fundo { get; set; }
        public FundoDistribuido FundoDistribuido { get; set; }
    }
}