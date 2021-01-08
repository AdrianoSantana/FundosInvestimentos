using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FundosInvestimentos.Models;

namespace FundosInvestimentos.Interfaces.TipoInstituicaoInterface
{
    public interface TipoInstituicaoInterface
    {
        public Task<IEnumerable<TipoInstituicao>> GetAllTiposInstituicao();
        Task<TipoInstituicao> GetTipoInstituicaoByName(string tipoInstituicao);
    }
}