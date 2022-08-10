namespace SellBicycleWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_HoaDon_NhapHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_HDDonNhap { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_SP { get; set; }

        public int? soluongnhap { get; set; }

        public int? dongianhap { get; set; }

        public int? thanhtien { get; set; }

        public virtual HoaDon_NhapHang HoaDon_NhapHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
