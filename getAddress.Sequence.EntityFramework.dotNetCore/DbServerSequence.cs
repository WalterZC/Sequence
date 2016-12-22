using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace getAddress.Sequence.EntityFramework
{

    [Table("DbServerSequence")]
    public  class DbServerSequence : ISequence
    {

        public DbServerSequence()
        {
            
        }
        public DbServerSequence(SequenceOptions options):this()
        {
            StartAt = options.StartAt;
            CurrentValue = StartAt;
            Increment = options.Increment;
            MaxValue = options.MaxValue;
            MinValue = options.MinValue;
            Cycle = options.Cycle;

        }

        public String Key { get; set; }
        public long StartAt { get;  set; }
        public int Increment { get;  set; }
        public long MaxValue { get;  set; }
        public long MinValue { get;  set; }
        public bool Cycle { get;  set; }
        public long CurrentValue { get; set; }


        public byte[] RowVersion { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
