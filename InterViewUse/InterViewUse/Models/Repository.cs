using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InterViewUse.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        NorthwindEntities db = null;
        DbSet<T> Dbset = null;
        public Repository()
        {
            db = new NorthwindEntities();
            Dbset = db.Set<T>();
        }
        public void Create(T _entity)
        {
            db.Entry(_entity).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(T _entity)
        {
            db.Entry(_entity).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Update(T _entity)
        {
            db.Entry(_entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return Dbset;
        }

        public T GetByID(int id)
        {
            return Dbset.Find(id);
        }       
    }
}