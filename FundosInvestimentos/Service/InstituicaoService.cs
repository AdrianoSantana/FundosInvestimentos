using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FundosInvestimentos.Interfaces;
using FundosInvestimentos.Interfaces.InstituicaoInterface;
using FundosInvestimentos.Models;

namespace FundosInvestimentos.Service
{
    public class InstituicaoService : InstituicaoServiceInterface
    {
        private IRepository<Instituicao> _repository;
        public InstituicaoService(IRepository<Instituicao> repository)
        {
            _repository = repository;
        }
        public async Task<bool> DeleteInstituicao(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Instituicao>> GetAllInstituicao()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Instituicao> GetInstituicaoById(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<Instituicao> PostInstituicao(Instituicao instituicao)
        {
            return await _repository.InsertAsync(instituicao);
        }

        public async Task<Instituicao> PutInstituicao(Instituicao instituicao)
        {
            return await _repository.UpdateAsync(instituicao);
        }
    }
}