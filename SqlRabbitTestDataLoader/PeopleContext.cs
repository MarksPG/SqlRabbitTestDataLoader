namespace SqlRabbitTestDataLoader
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PeopleContext : DbContext
    {
        public PeopleContext()
            : base("name=PeopleContext")
        {
        }

        public virtual DbSet<People> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
