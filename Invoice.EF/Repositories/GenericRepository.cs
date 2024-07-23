using Invoice.Core.Interfaces;
using Invoice.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.EF.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected AppDbContext Context;

        public GenericRepository(AppDbContext _Context)
        {
            Context = _Context;
        }

        public T GetById(int id) => Context.Set<T>().Find(id);


        public IEnumerable<T> GetAll() => Context.Set<T>().ToList();

        public T Add(T entity)
        {
            Context.Set<T>().Add(entity);

            return entity;
        }

        public T Update(T entity)
        {
            Context.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

    }
}
