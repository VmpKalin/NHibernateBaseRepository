using NHibernate;
using NHibernateCore.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace NHibernateCore.Context
{
    public abstract class MapperSessionBase<T, TKey> : IMapperSession<T, TKey> where T : NHibernateBaseEntity<TKey>
    {
        protected readonly ISession _session;
        protected ITransaction _transaction;

        public MapperSessionBase(ISession session)
        {
            _session = session;
        }

        public IQueryable<T> Entities { get => _session.Query<T>(); }

        public async Task AddAsync(T entity)
        {
            BeginTransaction();
            await _session.SaveAsync(entity);
            await CommitAsync();
            CloseTransaction();
        }

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void CloseTransaction()
        {
            if(_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public Task CommitAsync()
        {
            return _transaction?.CommitAsync();
        }

        public Task DeleteAsync(T entity)
        {
            return _session.DeleteAsync(entity);
        }

        public Task RollbackAsync()
        {
            return _transaction.RollbackAsync();
        }

        public Task SaveAsync(T entity)
        {
            return _session.SaveOrUpdateAsync(entity);
        }
    }
}
