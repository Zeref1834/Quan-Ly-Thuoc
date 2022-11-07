namespace QuanLyBanThuoc.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            PHIEUDATHANGs = new HashSet<PHIEUDATHANG>();
            PHIEUXUATKHOes = new HashSet<PHIEUXUATKHO>();
        }

        [Key]
        [StringLength(6)]
        public string MAKH { get; set; }

        [Required]
        [StringLength(20)]
        public string HOTENKH { get; set; }

        [Required]
        [StringLength(200)]
        public string DIACHIKH { get; set; }

        [Required]
        [StringLength(20)]
        public string DIENTHOAI { get; set; }

        [Required]
        [StringLength(6)]
        public string MALOAIKH { get; set; }

        public virtual LOAIKH LOAIKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDATHANG> PHIEUDATHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXUATKHO> PHIEUXUATKHOes { get; set; }
    }
}
