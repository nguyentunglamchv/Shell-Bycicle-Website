namespace SellBicycleWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            CT_DonHang = new HashSet<CT_DonHang>();
            HoaDonBans = new HashSet<HoaDonBan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_DH { get; set; }

        public int? ma_NV { get; set; }

        public int? ma_KH { get; set; }

        public DateTime? thoigian { get; set; }

        public int? tongtien { get; set; }

        [Required]
        [StringLength(50)]
        public string diachi_giaohang { get; set; }

        public int sdt_nguoinhan { get; set; }

        [Required]
        [StringLength(30)]
        public string hoten_nguoinhan { get; set; }

        [StringLength(30)]
        public string trangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DonHang> CT_DonHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }
    }
}
