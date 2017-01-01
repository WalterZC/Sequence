using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getAddress.Sequence.EntityFramework.MySql
{
    public class DbServerStateProvider:IStateProvider
    {
        private readonly SequenceDbContext DbContext;
        private readonly DbSet<DbServerSequence> DbSet;

        public DbServerStateProvider(DbContextOptions opt)
        {
            DbContext = new SequenceDbContext(opt);

            DbSet = DbContext.Set<DbServerSequence>();

        }

        public async Task<SequenceKey> AddAsync(ISequence sequence)
        {
            var sqlServerSequence = (DbServerSequence)sequence;

            sqlServerSequence.Key = Guid.NewGuid().ToString();
            sqlServerSequence.DateCreated = DateTime.UtcNow;

            DbSet.Add(sqlServerSequence);

           await SaveChangesAsync();

           return new SequenceKey { Value = sqlServerSequence.Key.ToString() };
        }

        public async Task<ISequence> GetAsync(SequenceKey sequenceKey)
        {
            var sequence = await DbSet.FirstOrDefaultAsync(s => s.Key == sequenceKey.Value);
            return sequence;
        }


        private async Task<int> SaveChangesAsync(bool handleConcurrencyExceptions = true)
        {
            try
            {
                return await Task.FromResult(DbContext.SaveChanges());
            }
            catch (DbUpdateConcurrencyException)
            {
                if (handleConcurrencyExceptions)
                {
                    return 0;
                }
                throw;
            }

        }

        public async Task<bool> UpdateAsync(SequenceKey sequenceKey, ISequence sequence)
        {
             
            var updateResult = await SaveChangesAsync();

            if (updateResult != 1)
            {
                Reload(sequence);

                return false;
            }
            return true;
        }

        private void Reload(ISequence sequence)
        {
            DbContext.Entry(sequence).Reload();
        }

        public async Task<ISequence> NewAsync(SequenceOptions options)
        {
            return await Task.FromResult(new DbServerSequence(options));
        }
    }
}
