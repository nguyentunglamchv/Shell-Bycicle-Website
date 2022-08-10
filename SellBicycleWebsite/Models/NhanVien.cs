namespace SellBicycleWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            Blogs = new HashSet<Blog>();
            DonHangs = new HashSet<DonHang>();
            HoaDon_NhapHang = new HashSet<HoaDon_NhapHang>();
            HoaDonBans = new HashSet<HoaDonBan>();
            NhanVien_DN = new HashSet<NhanVien_DN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_NV { get; set; }

        [StringLength(30)]
        public string ten_NV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysinh_NV { get; set; }

        public int? ma_DV { get; set; }

        [StringLength(30)]
        public string email_NV { get; set; }

        public int? sdt_NV { get; set; }

        [StringLength(50)]
        public string diachi_NV { get; set; }

        [StringLength(40)]
        public string chuvu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? batdau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blog> Blogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        public virtual DonVi DonVi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon_NhapHang> HoaDon_NhapHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien_DN> NhanVien_DN { get; set; }
    }
}
