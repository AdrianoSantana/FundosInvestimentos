using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FundosInvestimentos.Models;

namespace FundosInvestimentos.Interfaces.InstituicaoInterface
{
    public interface InstituicaoServiceInterface
    {
        Task<Instituicao> GetInstituicaoById(Guid id);
        Task<IEnumerable<Instituicao>> GetAllInstituicao();

        Task<Instituicao> PostInstituicao(Instituicao instituicao);

        Task<Instituicao> PutInstituicao(Instituicao instituicao);

        Task<bool> DeleteInstituicao(Guid id);

    }
}