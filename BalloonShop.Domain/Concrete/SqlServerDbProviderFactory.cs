using BalloonShop.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonShop.Domain.Concrete
{
    class SqlServerDbProviderFactory : IDbProviderFactory
    {
        public IDbProvider GetDbProvider()
        {
            // TODO: Apply Singleton Pattern
            return SqlServerDbProvider.Instance();
        }
    }
}
