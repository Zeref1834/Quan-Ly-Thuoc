namespace QuanLyBanThuoc.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAPKHO")]
    public partial class PHIEUNHAPKHO
    {
        [Key]
        [StringLength(6)]
        public string MAPHIEUNK { get; set; }

        public DateTime NGAYNK { get; set; }

        [Required]
        [StringLength(6)]
        public string MANV { get; set; }

        [Required]
        [StringLength(6)]
        public string MAKHO { get; set; }

        [Required]
        [StringLength(6)]
        public string MATHUOC { get; set; }

        public virtual KHO KHO { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual THUOC THUOC { get; set; }
    }
}
