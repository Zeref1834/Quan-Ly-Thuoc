namespace QuanLyBanThuoc.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUTHANHLI")]
    public partial class PHIEUTHANHLI
    {
        [Key]
        [StringLength(6)]
        public string MAPHIEUTL { get; set; }

        [Required]
        [StringLength(6)]
        public string MATHUOC { get; set; }

        public int SOLUONG { get; set; }

        [Required]
        [StringLength(6)]
        public string MAKHO { get; set; }

        public DateTime NGAYTHANH { get; set; }

        [Required]
        [StringLength(6)]
        public string MANV { get; set; }

        public virtual KHO KHO { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual THUOC THUOC { get; set; }
    }
}
