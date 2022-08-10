namespace SellBicycleWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_HoaDonBan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maHD_ban { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_SP { get; set; }

        public int? soluong { get; set; }

        public int? dongia { get; set; }

        public int? thanhtien { get; set; }

        [StringLength(100)]
        public string ghichu { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual HoaDonBan HoaDonBan { get; set; }
    }
}
