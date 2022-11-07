namespace QuanLyBanThuoc.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUDATHANG")]
    public partial class PHIEUDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUDATHANG()
        {
            PHIEUXUATKHOes = new HashSet<PHIEUXUATKHO>();
        }

        [Key]
        [StringLength(6)]
        public string MAPHIEUDH { get; set; }

        [Required]
        [StringLength(6)]
        public string MAKH { get; set; }

        [Required]
        [StringLength(6)]
        public string MAHT { get; set; }

        [Required]
        [StringLength(6)]
        public string MATHUOC { get; set; }

        public int SOLUONG { get; set; }

        public DateTime NGAYGIAO { get; set; }

        [Required]
        [StringLength(200)]
        public string NOIGIAO { get; set; }

        public DateTime NGAYLAP { get; set; }

        public int? TONGTIEN { get; set; }

        [Required]
        [StringLength(6)]
        public string MANV { get; set; }

        public virtual HT_THANHTOAN HT_THANHTOAN { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual THUOC THUOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXUATKHO> PHIEUXUATKHOes { get; set; }
    }
}
