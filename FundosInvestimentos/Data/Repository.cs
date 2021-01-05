using System;
using System.Linq;
using FundosInvestimentos.Models;
using Microsoft.EntityFrameworkCore;

namespace FundosInvestimentos.Data
{
    public class Repository : IRepository
    {
        private readonly MyContext _context;
        public Repository(MyContext context)
        {
            _context = context;
        }
        public T Delete<T>(T entity) where T : class
        {
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public Instituicao[] GetAllInstituicao()
        {
            try
            {
                return _context.Instituicao.OrderBy(instituicao => instituicao.RazaoSocial)
                            .Include(instituicao => instituicao.TipoInstituicao)
                            .ToArray();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public Instituicao[] GetAllInstituicaoByTipo()
        {
            try
            {
                return _context.Instituicao.ToArray();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public Instituicao GetInstituicaoById(Guid id)
        {
            try
            {
                return _context.Instituicao.Include(instituicao => instituicao.TipoInstituicao)
                            .FirstOrDefault(instituicao => instituicao.Id.Equals(id));
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public T Post<T>(T entity) where T : class
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public T Update<T>(T entity) where T : class
        {
            try
            {
                _context.Update(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}