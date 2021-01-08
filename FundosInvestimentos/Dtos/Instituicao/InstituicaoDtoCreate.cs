namespace FundosInvestimentos.Dtos.Instituicao
{
    public class InstituicaoDtoCreate
    {
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string tipo { get; set; }

        public string AnoCriacao { get; set; }
    }
}