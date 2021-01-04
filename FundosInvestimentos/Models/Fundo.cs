using System;
using System.Collections.Generic;

namespace FundosInvestimentos.Models
{
    public class Fundo : BaseModel
    {
        public Fundo()
        {

        }
        public Fundo(string cNPJ, double saldo, string razaoSocialGestor, string razaoSocialAdministrador, string razaoSocialDistribuidor, DateTime dataInicio, string codigoAnbima)
        {
            this.CNPJ = cNPJ;
            this.Saldo = saldo;
            this.RazaoSocialGestor = razaoSocialGestor;
            this.RazaoSocialAdministrador = razaoSocialAdministrador;
            this.RazaoSocialDistribuidor = razaoSocialDistribuidor;
            this.DataInicio = dataInicio;
            this.CodigoAnbima = codigoAnbima;

        }
        public string CNPJ { get; set; }
        public double Saldo { get; set; }

        public string RazaoSocialGestor { get; set; }
        public string RazaoSocialAdministrador { get; set; }
        public string RazaoSocialDistribuidor { get; set; }

        public DateTime DataInicio { get; set; }

        public string CodigoAnbima { get; set; }

        public Guid InstituicaoId { get; set; }
        public Instituicao Instituicao { get; set; }

        public IEnumerable<FundoFundosDistribuidos> FundoFundosDistribuidos { get; set; }
    }
}