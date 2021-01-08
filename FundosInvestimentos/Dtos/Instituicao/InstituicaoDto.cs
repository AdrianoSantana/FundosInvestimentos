using System;

namespace FundosInvestimentos.Dtos
{
    public class InstituicaoDto
    {
        public Guid Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }

        public string TipoInstituicao { get; set; }

        public int IdadeInstituicao { get; set; }
    }
}