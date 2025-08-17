using System.Data;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.UnitOfWork
{
    public class AdoNetUnitOfWork : IDisposable
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        public IDbConnection Connection => _connection;
        public IDbTransaction Transaction => _transaction;
        public AdoNetUnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }
        public void Commit()
        {
            _transaction?.Commit();
            _transaction?.Dispose();
            _transaction = null;
        }
        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
            _transaction = null;
        }
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }
            _connection?.Dispose();
        }
    }
}
