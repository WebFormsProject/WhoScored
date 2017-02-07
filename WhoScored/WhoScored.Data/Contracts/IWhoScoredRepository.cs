using System.Collections.Generic;

namespace WhoScored.Data.Contracts
{
    public interface IWhoScoredRepository<T> where T : class
    {
        T GetById(object id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
