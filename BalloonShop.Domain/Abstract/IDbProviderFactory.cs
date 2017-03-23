using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonShop.Domain.Abstract
{
    interface IDbProviderFactory
    {
        /// <summary>
        /// Create the corresponding Database Provider
        /// Pattern: Factory Method
        /// </summary>
        /// <returns></returns>
        IDbProvider GetDbProvider();
    }
}
