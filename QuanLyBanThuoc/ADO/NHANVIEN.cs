namespace QuanLyBanThuoc.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            PHIEUDATHANGs = new HashSet<PHIEUDATHANG>();
            PHIEUNHAPKHOes = new HashSet<PHIEUNHAPKHO>();
            PHIEUTHANHLIs = new HashSet<PHIEUTHANHLI>();
            PHIEUXUATKHOes = new HashSet<PHIEUXUATKHO>();
        }

        [Key]
        [StringLength(6)]
        public string MANV { get; set; }

        [Required]
        [StringLength(20)]
        public string HOTENNV { get; set; }

        [Required]
        [StringLength(3)]
        public string GIOITINH { get; set; }

        public DateTime NGAYSINH { get; set; }

        [Required]
        [StringLength(200)]
        public string DIACHI { get; set; }

        [Required]
        [StringLength(20)]
        public string DIENTHOAI { get; set; }

        [Required]
        [StringLength(100)]
        public string LUONG { get; set; }

        [Required]
        [StringLength(100)]
        public string TENLOAINV { get; set; }

        [Required]
        [StringLength(30)]
        public string TENDN { get; set; }

        [Required]
        [StringLength(20)]
        public string MATKHAU { get; set; }

        [StringLength(200)]
        public string HINHANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDATHANG> PHIEUDATHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAPKHO> PHIEUNHAPKHOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHANHLI> PHIEUTHANHLIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXUATKHO> PHIEUXUATKHOes { get; set; }
    }
}
