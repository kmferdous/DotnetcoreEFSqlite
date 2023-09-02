using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Infrastructure.Configs
{
    public interface IDbConfig
    {
        public string DbServer { get; }

        public string DbName { get; }
    }
}
