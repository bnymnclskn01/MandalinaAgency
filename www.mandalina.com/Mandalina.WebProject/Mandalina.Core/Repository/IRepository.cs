using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.Repository
{
    public interface IRepository<T> where T : class
    {

        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        //void DeleteList(List<T> entity);// ? Kullanılabilirse Yaz


        T GetById(Expression<Func<T, bool>> Id);
        T GetById(Expression<Func<T, bool>> Id, string Include1);
        T GetById(Expression<Func<T, bool>> Id, string Include1, string Include2);
        T GetById(Expression<Func<T, bool>> Id, string Include1, string Include2, string Include3);



        List<T> GetAll(Expression<Func<T, bool>> Where);
        List<T> GetAll(Expression<Func<T, bool>> Where, string Include1);
        List<T> GetAll(Expression<Func<T, bool>> Where, string Include1, string Include2);
        List<T> GetAll(Expression<Func<T, bool>> Where, string Include1, string Include2, string Include3);

        IQueryable<T> QGetBy(Expression<Func<T, bool>> Where);
        IQueryable<T> QGetBy(Expression<Func<T, bool>> Where, string Include1);
        IQueryable<T> QGetBy(Expression<Func<T, bool>> Where, string Include1, string Include2);
        IQueryable<T> QGetBy(Expression<Func<T, bool>> Where, string Include1, string Include2, string Include3);

        IQueryable<T> QGetAll();

        int Count(Expression<Func<T, bool>> Where);
        bool Any(Expression<Func<T, bool>> Where);

        int Save();


    }
}
