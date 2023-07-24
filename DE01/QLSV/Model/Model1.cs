using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLSV.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<LOP> LOPs { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIENs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LOP>()
                .Property(e => e.MALOP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.MASV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.MALOP)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
