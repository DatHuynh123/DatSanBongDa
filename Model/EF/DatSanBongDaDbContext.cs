namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatSanBongDaDbContext : DbContext
    {
        public DatSanBongDaDbContext()
            : base("name=DatSanBongDaDbContext1")
        {
        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<Loaisan> Loaisans { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<QuyenHan> QuyenHans { get; set; }
        public virtual DbSet<San> Sans { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<ThanhVien> ThanhViens { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.MaSan)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaSan)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.MaImage)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.Image1)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<San>()
                .Property(e => e.MaSan)
                .IsUnicode(false);

            modelBuilder.Entity<San>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 3);

            modelBuilder.Entity<User>()
                .Property(e => e.PW)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.khachhangs)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IDKH);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Menus)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IDMN);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MenuTypes)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IDMNT);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Slides)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IDSL);
        }
    }
}
