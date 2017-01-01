using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getAddress.Sequence.EntityFramework.MySql
{
    public interface IRowVersion
    {
        long RowVersion { get; set; }

        void OnSavingChanges();
    }
}
