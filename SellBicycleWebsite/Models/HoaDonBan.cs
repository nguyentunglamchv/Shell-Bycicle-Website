namespace SellBicycleWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonBan")]
    public partial class HoaDonBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonBan()
        {
            CT_HoaDonBan = new HashSet<CT_HoaDonBan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maHD_ban { get; set; }

        public DateTime? ngaylap_hoadon { get; set; }

        public int? ma_DH { get; set; }

        public int? ma_NV { get; set; }

        public int? tongtien { get; set; }

        public int? khachdua { get; set; }

        public int? tienthua { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HoaDonBan> CT_HoaDonBan { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
