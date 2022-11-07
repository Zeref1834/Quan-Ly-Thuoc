namespace QuanLyBanThuoc.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOTHUOC")]
    public partial class LOTHUOC
    {
        [Key]
        [StringLength(6)]
        public string MALO { get; set; }

        [Required]
        [StringLength(100)]
        public string TENLO { get; set; }

        public DateTime NGAYSX { get; set; }

        public DateTime NGAYHH { get; set; }

        public int SOLUONG { get; set; }

        [Required]
        [StringLength(6)]
        public string MATHUOC { get; set; }

        public int THANHTIEN { get; set; }

        public virtual THUOC THUOC { get; set; }
    }
}
