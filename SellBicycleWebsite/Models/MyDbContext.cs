using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SellBicycleWebsite.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyDbContext2")
        {
        }

        public virtual DbSet<Anh_Blogs> Anh_Blogs { get; set; }
        public virtual DbSet<Anh_SP> Anh_SP { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<CT_DonHang> CT_DonHang { get; set; }
        public virtual DbSet<CT_HoaDon_NhapHang> CT_HoaDon_NhapHang { get; set; }
        public virtual DbSet<CT_HoaDonBan> CT_HoaDonBan { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<HoaDon_NhapHang> HoaDon_NhapHang { get; set; }
        public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Loai_SP> Loai_SP { get; set; }
        public virtual DbSet<NCC> NCCs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhanVien_DN> NhanVien_DN { get; set; }
        public virtual DbSet<QuyenNV> QuyenNVs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anh_Blogs>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<Anh_SP>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.noidung)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .HasMany(e => e.Anh_Blogs)
                .WithRequired(e => e.Blog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.HoaDonBans)
                .WithOptional(e => e.DonHang)
                .WillCascadeOnDelete();

            modelBuilder.Entity<HoaDon_NhapHang>()
                .HasMany(e => e.CT_HoaDon_NhapHang)
                .WithRequired(e => e.HoaDon_NhapHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDonBan>()
                .HasMany(e => e.CT_HoaDonBan)
                .WithRequired(e => e.HoaDonBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.pw)
                .IsUnicode(false);

            modelBuilder.Entity<NCC>()
                .Property(e => e.email_NCC)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.email_NV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.Blogs)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.tacgia);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.NhanVien_DN)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien_DN>()
                .Property(e => e.tendn_NV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien_DN>()
                .Property(e => e.mk_NV)
                .IsUnicode(false);

            modelBuilder.Entity<QuyenNV>()
                .HasMany(e => e.NhanVien_DN)
                .WithRequired(e => e.QuyenNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.link_anhdaidien)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.Anh_SP)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CT_DonHang)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CT_HoaDon_NhapHang)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CT_HoaDonBan)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);
        }
    }
}
