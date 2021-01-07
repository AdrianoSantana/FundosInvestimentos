using System;
using AutoMapper;
using FundosInvestimentos.Dtos;
using FundosInvestimentos.Models;

namespace FundosInvestimentos.Helpers
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Instituicao, InstituicaoDto>()
                .ForMember(
                    dest => dest.IdadeInstituicao,
                    opt => opt.MapFrom(src => DateTime.UtcNow.Year - Int32.Parse(src.AnoCriacao))
                );
        }
    }
}