namespace SellBicycleWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_KH { get; set; }

        [StringLength(30)]
        public string ten_KH { get; set; }

        public int? CMND_KH { get; set; }

        [StringLength(3)]
        public string GioiTinh_KH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh_KH { get; set; }

        [StringLength(50)]
        public string DiaChi_KH { get; set; }

        public int? SDT_KH { get; set; }

        [StringLength(30)]
        public string username { get; set; }

        [StringLength(20)]
        public string pw { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
