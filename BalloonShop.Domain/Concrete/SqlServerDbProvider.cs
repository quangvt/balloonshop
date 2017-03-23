using BalloonShop.Domain.Abstract;

namespace BalloonShop.Domain.Concrete
{
    public class SqlServerDbProvider : IDbProvider
    {
        private static SqlServerDbProvider _instance;

        // Lock synchronization object
        private static object syncLock = new object();

        private SqlServerDbProvider()
        {
            // Get "System.Data.SqlClient"
        }

        public static SqlServerDbProvider Instance()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_instance == null)
            {
                lock(syncLock)
                {
                    if(_instance == null)
                    {
                        _instance = new SqlServerDbProvider();
                    }
                }
            }

            return _instance;
        }
    }
}
