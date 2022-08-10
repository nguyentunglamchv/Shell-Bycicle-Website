namespace SellBicycleWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            Anh_SP = new HashSet<Anh_SP>();
            CT_DonHang = new HashSet<CT_DonHang>();
            CT_HoaDon_NhapHang = new HashSet<CT_HoaDon_NhapHang>();
            CT_HoaDonBan = new HashSet<CT_HoaDonBan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_SP { get; set; }

        [StringLength(20)]
        public string ten_SP { get; set; }

        public int? ma_NCC { get; set; }

        public int? soluong { get; set; }

        public int? dongiaban { get; set; }

        public int? dongianhap { get; set; }

        [StringLength(800)]
        public string thongso { get; set; }

        public int? maLoai { get; set; }

        [StringLength(100)]
        public string mota { get; set; }

        [StringLength(50)]
        public string link_anhdaidien { get; set; }

        public double? khuyenmai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anh_SP> Anh_SP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DonHang> CT_DonHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HoaDon_NhapHang> CT_HoaDon_NhapHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HoaDonBan> CT_HoaDonBan { get; set; }

        public virtual Loai_SP Loai_SP { get; set; }

        public virtual NCC NCC { get; set; }
    }
}
