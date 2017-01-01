

using Microsoft.EntityFrameworkCore;

namespace getAddress.Sequence.EntityFramework.SqlServer
{
    public class DbServerStateProviderFactory
    {
        public static IStateProvider Get(DbContextOptions opt)
        {
            return new DbServerStateProvider(opt);
        }
    }
}
