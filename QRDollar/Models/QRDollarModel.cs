namespace QRDollar.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QRDollarModel : DbContext
    {
        public QRDollarModel()
            : base("name=QRDollarModel")
        {
        }

        public virtual DbSet<Dollar> Dollars { get; set; }
        public virtual DbSet<Dollar_Find> Dollar_Find { get; set; }
        public virtual DbSet<QR> QRs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dollar>()
                .Property(e => e.Icon)
                .IsFixedLength();

            modelBuilder.Entity<Dollar>()
                .HasMany(e => e.QRs)
                .WithRequired(e => e.Dollar)
                .HasForeignKey(e => e.Dollar_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
