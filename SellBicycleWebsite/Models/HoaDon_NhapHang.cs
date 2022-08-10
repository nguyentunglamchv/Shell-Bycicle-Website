namespace SellBicycleWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HoaDon_NhapHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon_NhapHang()
        {
            CT_HoaDon_NhapHang = new HashSet<CT_HoaDon_NhapHang>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_HDDonNhap { get; set; }

        public int? ma_NCC { get; set; }

        public int? ma_NV { get; set; }

        public DateTime? thoigian { get; set; }

        public int? tongtien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HoaDon_NhapHang> CT_HoaDon_NhapHang { get; set; }

        public virtual NCC NCC { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
