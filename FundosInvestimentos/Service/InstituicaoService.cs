using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FundosInvestimentos.Dtos.Instituicao;
using FundosInvestimentos.Interfaces;
using FundosInvestimentos.Interfaces.InstituicaoInterface;
using FundosInvestimentos.Interfaces.TipoInstituicaoInterface;
using FundosInvestimentos.Models;

namespace FundosInvestimentos.Service
{
    public class InstituicaoService : InstituicaoServiceInterface
    {
        private IRepository<Instituicao> _repository;
        private IMapper _mapper;

        private readonly TipoInstituicaoInterface _instituicaoService;
        public InstituicaoService(IRepository<Instituicao> repository, IMapper mapper, TipoInstituicaoInterface instituicaoService)
        {
            _repository = repository;
            _mapper = mapper;
            _instituicaoService = instituicaoService;
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

        public async Task<Instituicao> PostInstituicao(InstituicaoDtoCreate instituicao)
        {
            var tipoInstituicao = (await _instituicaoService.GetTipoInstituicaoByName(instituicao.tipo));
            Guid idTipoInstituicao = tipoInstituicao.Id;
            var instituicaoFormatoOriginal = new Instituicao()
            {
                CNPJ = instituicao.CNPJ,
                RazaoSocial = instituicao.RazaoSocial,
                AnoCriacao = instituicao.AnoCriacao,
                TipoInstituicaoId = idTipoInstituicao,
                TipoInstituicao = tipoInstituicao
            };

            return await _repository.InsertAsync(instituicaoFormatoOriginal);
        }

        public async Task<Instituicao> PutInstituicao(Instituicao instituicao)
        {
            return await _repository.UpdateAsync(instituicao);
        }
    }
}