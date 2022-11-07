namespace QuanLyBanThuoc.ADO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelQLThuoc : DbContext
    {
        public ModelQLThuoc()
            : base("name=ModelQLThuoc")
        {
        }

        public virtual DbSet<DVTINH> DVTINHs { get; set; }
        public virtual DbSet<HT_THANHTOAN> HT_THANHTOAN { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<KHO> KHOes { get; set; }
        public virtual DbSet<LOAIKH> LOAIKHs { get; set; }
        public virtual DbSet<LOAITHUOC> LOAITHUOCs { get; set; }
        public virtual DbSet<LOTHUOC> LOTHUOCs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHIEUDATHANG> PHIEUDATHANGs { get; set; }
        public virtual DbSet<PHIEUNHAPKHO> PHIEUNHAPKHOes { get; set; }
        public virtual DbSet<PHIEUTHANHLI> PHIEUTHANHLIs { get; set; }
        public virtual DbSet<PHIEUXUATKHO> PHIEUXUATKHOes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<THUOC> THUOCs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DVTINH>()
                .HasMany(e => e.THUOCs)
                .WithRequired(e => e.DVTINH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HT_THANHTOAN>()
                .HasMany(e => e.PHIEUDATHANGs)
                .WithRequired(e => e.HT_THANHTOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.PHIEUDATHANGs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.PHIEUXUATKHOes)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHO>()
                .HasMany(e => e.PHIEUNHAPKHOes)
                .WithRequired(e => e.KHO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHO>()
                .HasMany(e => e.PHIEUTHANHLIs)
                .WithRequired(e => e.KHO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHO>()
                .HasMany(e => e.PHIEUXUATKHOes)
                .WithRequired(e => e.KHO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAIKH>()
                .HasMany(e => e.KHACHHANGs)
                .WithRequired(e => e.LOAIKH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAITHUOC>()
                .HasMany(e => e.THUOCs)
                .WithRequired(e => e.LOAITHUOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUDATHANGs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUNHAPKHOes)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUTHANHLIs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUXUATKHOes)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUDATHANG>()
                .HasMany(e => e.PHIEUXUATKHOes)
                .WithRequired(e => e.PHIEUDATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUOC>()
                .HasMany(e => e.LOTHUOCs)
                .WithRequired(e => e.THUOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUOC>()
                .HasMany(e => e.PHIEUDATHANGs)
                .WithRequired(e => e.THUOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUOC>()
                .HasMany(e => e.PHIEUNHAPKHOes)
                .WithRequired(e => e.THUOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUOC>()
                .HasMany(e => e.PHIEUTHANHLIs)
                .WithRequired(e => e.THUOC)
                .WillCascadeOnDelete(false);
        }
    }
}
