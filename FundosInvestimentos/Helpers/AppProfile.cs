using System;
using AutoMapper;
using FundosInvestimentos.Dtos;
using FundosInvestimentos.Dtos.Instituicao;
using FundosInvestimentos.Interfaces.TipoInstituicaoInterface;
using FundosInvestimentos.Models;

namespace FundosInvestimentos.Helpers
{
    public class AppProfile : Profile
    {
        private readonly TipoInstituicaoInterface _tipoInstituicaoService;
        public AppProfile(TipoInstituicaoInterface tipoInstituicaoService)
        {
            _tipoInstituicaoService = tipoInstituicaoService;
        }
        public AppProfile()
        {
            CreateMap<Instituicao, InstituicaoDto>()
                .ForMember(
                    dest => dest.IdadeInstituicao,
                    opt => opt.MapFrom(src => DateTime.UtcNow.Year - Int32.Parse(src.AnoCriacao))
                )
                .ForMember(
                    dest => dest.TipoInstituicao,
                    opt => opt.MapFrom(src => src.TipoInstituicao.Tipo)
                );
        }
    }
}