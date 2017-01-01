
using Microsoft.EntityFrameworkCore;
 


namespace getAddress.Sequence.EntityFramework.SqlServer
{
   
    public class SequenceDbContext : DbContext
    {

        public SequenceDbContext()
        {
        }

        public SequenceDbContext(DbContextOptions opt)
            : base(opt)
        {

        }

        public DbSet<DbServerSequence> Sequences { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DbServerSequence>(e =>
            {
                e.HasKey(x => x.Key);
                e.Property(x => x.RowVersion).IsRowVersion().IsConcurrencyToken();
            });
        }
    }
}
