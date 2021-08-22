using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLSinhVien.Entites
{
    public partial class ModelSinhVien : DbContext
    {
        public ModelSinhVien()
            : base("name=ModelSinhVien")
        {
        }

        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khoa>()
                .Property(e => e.KhoaID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Khoa>()
                .HasMany(e => e.SinhViens)
                .WithRequired(e => e.Khoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MSSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.KhoaID)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
