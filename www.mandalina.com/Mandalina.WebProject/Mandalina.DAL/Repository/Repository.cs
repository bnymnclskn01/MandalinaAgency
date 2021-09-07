using Mandalina.Core.Repository;
using Mandalina.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.DAL.Repository
{
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {

        private DataBaseContext db;

        public Repository()
        {
            db = CreateContext();
        }



        public int Add(T entity)
        {
            if (entity is BaseEntity)
            {
                BaseEntity obj = entity as BaseEntity;
                DateTime now = DateTime.Now;
                obj.CreateDate = now;
                obj.IsDeleted = false;
            }
            //else if(entity is BaseEntity2)
            //{
            //    BaseEntity2 obj2 = new BaseEntity2();
            //    obj2.CreateDate = DateTime.Now; 
            //    obj2.IsDeleted = false;

            //}

            db.Set<T>().Add(entity);

            return Save();
        }

        public bool Any(Expression<Func<T, bool>> Where)
        {
            return db.Set<T>().Any(Where); //Databasede Var mı yokmu sorusunun cevabı niteliğindedir.
        }

        public int Count(Expression<Func<T, bool>> Where)
        {
            return db.Set<T>().Count(Where);
        }


        public int Delete(T entity)
        {
            db.Set<T>().Remove(entity);

            return Save();
        }


        public List<T> ListGetAll() // Listelemek için kullanacağız.
        {
            return db.Set<T>().ToList();
        }

        public List<T> Listele()
        {
            List<T> liste = db.Set<T>().ToList();
            return liste;
        }

        public List<T> GetAll(Expression<Func<T, bool>> Where)
        {
            return db.Set<T>().Where(Where).ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> Where, string Include1)
        {
            return db.Set<T>().Include(Include1).Where(Where).ToList();

        }

        public List<T> GetAll(Expression<Func<T, bool>> Where, string Include1, string Include2)
        {
            return db.Set<T>().Include(Include1).Include(Include2).Where(Where).ToList();

        }

        public List<T> GetAll(Expression<Func<T, bool>> Where, string Include1, string Include2, string Include3)
        {
            return db.Set<T>().Include(Include1).Include(Include2).Include(Include3).Where(Where).ToList();

        }


        public T GetById(Expression<Func<T, bool>> Id)
        {
            return db.Set<T>().FirstOrDefault(Id);

        }

        public T GetByIdAsNotTracking(Expression<Func<T, bool>> Id)
        {
            return db.Set<T>().AsNoTracking().FirstOrDefault(Id);

        }


        public T GetById(Expression<Func<T, bool>> Id, string Include1)
        {
            return db.Set<T>().Include(Include1).FirstOrDefault();
        }


        public T GetById(Expression<Func<T, bool>> Id, string Include1, string Include2)
        {
            return db.Set<T>().Include(Include1).Include(Include2).FirstOrDefault();
        }


        public T GetById(Expression<Func<T, bool>> Where, string Include1, string Include2, string Include3)
        {
            return db.Set<T>().Include(Include1).Include(Include2).Include(Include3).FirstOrDefault(Where);

        }

        public IQueryable<T> QGetAll()
        {
            return db.Set<T>().AsQueryable();
        }

        public IQueryable<T> QGetBy(Expression<Func<T, bool>> Where)
        {
            return db.Set<T>().Where(Where).AsQueryable();
        }
        public IQueryable<T> QGetByTracking(Expression<Func<T, bool>> Where)
        {
            return db.Set<T>().AsNoTracking().Where(Where).AsQueryable();
        }
        public IQueryable<T> QGetByTracking(Expression<Func<T, bool>> Where, string Include1)
        {
            return db.Set<T>().Include(Include1).AsNoTracking().Where(Where).AsQueryable();
        }

        public IQueryable<T> QGetBy(Expression<Func<T, bool>> Where, string Include1, string Include2)
        {
            return db.Set<T>().Include(Include1).Include(Include2).Where(Where).AsQueryable();
        }

        public IQueryable<T> QGetByTracking(Expression<Func<T, bool>> Where, string Include1, string Include2)
        {
            return db.Set<T>().AsNoTracking().Include(Include1).Include(Include2).Where(Where).AsQueryable();
        }

        public IQueryable<T> QGetBy(Expression<Func<T, bool>> Where, string Include1, string Include2, string Include3)
        {
            return db.Set<T>().Include(Include1).Include(Include2).Include(Include3).Where(Where).AsQueryable();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public int Update(T entity)
        {



            if (entity is BaseEntity)
            {
                BaseEntity obj = entity as BaseEntity;
                DateTime now = DateTime.Now;
                obj.UpdateDate = now;

            }
            //else if (entity is BaseEntity2)
            //{
            //    BaseEntity2 obj = new BaseEntity2();
            //    DateTime now = DateTime.Now;
            //    obj.UpdateDate = now;


            //}


            return Save();
        }

        public IQueryable<T> QGetBy(Expression<Func<T, bool>> Where, string Include1)
        {
            return db.Set<T>().Include(Include1).Where(Where).AsQueryable();
        }
    }
}
