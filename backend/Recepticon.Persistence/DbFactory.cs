using System;
namespace Recepticon.Persistence
{
    public class DbFactory : IDisposable
    {
        private bool _disposed;
        private Func<RecepticonDbContext> _instanceFunc;
        private RecepticonDbContext _dbContext;
        public RecepticonDbContext DbContext => _dbContext ?? (_dbContext = _instanceFunc.Invoke());

        public DbFactory(Func<RecepticonDbContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }

        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }
}
