using NHibernateCore.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace NHibernateCore.Context
{
    public interface IMapperSession<T, TKey> where T : NHibernateBaseEntity<TKey>
    {
        void BeginTransaction();
        Task CommitAsync();
        Task RollbackAsync();
        void CloseTransaction();
        Task AddAsync(T entity);
        Task SaveAsync(T entity);
        Task DeleteAsync(T entity);

        IQueryable<T> Entities { get; }
    }
}
