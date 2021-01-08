using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundosInvestimentos.Interfaces;
using FundosInvestimentos.Interfaces.TipoInstituicaoInterface;
using FundosInvestimentos.Models;

namespace FundosInvestimentos.Service
{
    public class TipoInstituicaoService : TipoInstituicaoInterface
    {
        private readonly IRepository<TipoInstituicao> _repository;
        public TipoInstituicaoService(IRepository<TipoInstituicao> repository)
        {
            _repository = repository;
        }

        public async Task<TipoInstituicao> GetTipoInstituicaoByName(string tipoInstituicao)
        {
            var tiposInstituicoes = await _repository.SelectAsync();
            var instituicaoProcurada = tiposInstituicoes.SingleOrDefault(instituicao => instituicao.Tipo.Equals(tipoInstituicao));
            return instituicaoProcurada;
        }

        async Task<IEnumerable<TipoInstituicao>> TipoInstituicaoInterface.GetAllTiposInstituicao()
        {
            return await _repository.SelectAsync();
        }
    }
}