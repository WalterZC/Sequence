
using Microsoft.EntityFrameworkCore;
 


namespace getAddress.Sequence.EntityFramework
{
   
    public class SequenceDbContext : DbContext
    {
        private readonly bool _configured;

        public SequenceDbContext()
        {
            _configured = false;
        }
        public SequenceDbContext(DbContextOptions opt)
            : base(opt)
        {
            _configured = true;
        }

        public DbSet<DbServerSequence> Sequences { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DbServerSequence>(e =>
            {
                e.HasKey(x => x.Key);
                e.Property(x => x.RowVersion).IsRowVersion();
            });           
        }
    }
}
