namespace SellBicycleWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NhanVien_DN
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_NV { get; set; }

        [StringLength(20)]
        public string tendn_NV { get; set; }

        [StringLength(20)]
        public string mk_NV { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maquyen { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual QuyenNV QuyenNV { get; set; }
    }
}
