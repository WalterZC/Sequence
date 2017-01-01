using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getAddress.Sequence.EntityFramework.SqlServer
{
    interface IRowVersion
    {
        byte[] RowVersion { get; set; }
    }
}
