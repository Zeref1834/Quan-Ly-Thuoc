namespace QuanLyBanThuoc.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUXUATKHO")]
    public partial class PHIEUXUATKHO
    {
        [Key]
        [StringLength(6)]
        public string MAPHIEUXK { get; set; }

        [Required]
        [StringLength(6)]
        public string MAPHIEUDH { get; set; }

        [Required]
        [StringLength(6)]
        public string MAKH { get; set; }

        [StringLength(6)]
        public string MATHUOC { get; set; }

        public int? SOLUONG { get; set; }

        [Required]
        [StringLength(6)]
        public string MAKHO { get; set; }

        public DateTime NGAYXUAT { get; set; }

        [Required]
        [StringLength(6)]
        public string MANV { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual KHO KHO { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHIEUDATHANG PHIEUDATHANG { get; set; }
    }
}
