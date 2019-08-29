
namespace ExemploBaseEF.Infra.Data.Repository
{
    using ExemploBaseEF.Entities;
    using ExemploBaseEF.Interfaces;
    using ExemploBaseEF.Infra.Data.Context;
    using System.Collections.Generic;
    using System.Linq;

    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        public readonly ExemploBaseEFContext context;

        public BaseRepository(ExemploBaseEFContext context)
        {
            this.context = context;
        }

        public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            context.Set<T>().Remove(SelectById(id));
            context.SaveChanges();
        }

        public IList<T> SelectAll()
        {
            return context.Set<T>().ToList();
        }

        public T SelectById(long id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> GetQuery()
        {
            return context.Set<T>().AsQueryable();
        }

        public int RowsCount()
        {
            return context.Set<T>().Count();
        }

    }
}
