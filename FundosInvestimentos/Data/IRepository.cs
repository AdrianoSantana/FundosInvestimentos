using System;
using FundosInvestimentos.Models;

namespace FundosInvestimentos.Data
{
    public interface IRepository
    {
        T Post<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
        T Update<T>(T entity) where T : class;

        Instituicao[] GetAllInstituicao();

        Instituicao[] GetAllInstituicaoByTipo();
        Instituicao GetInstituicaoById(Guid id);
    }
}