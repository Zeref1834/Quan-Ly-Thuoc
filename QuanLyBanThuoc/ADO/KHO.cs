namespace QuanLyBanThuoc.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHO")]
    public partial class KHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHO()
        {
            PHIEUNHAPKHOes = new HashSet<PHIEUNHAPKHO>();
            PHIEUTHANHLIs = new HashSet<PHIEUTHANHLI>();
            PHIEUXUATKHOes = new HashSet<PHIEUXUATKHO>();
        }

        [Key]
        [StringLength(6)]
        public string MAKHO { get; set; }

        [Required]
        [StringLength(100)]
        public string TENKHO { get; set; }

        [Required]
        [StringLength(200)]
        public string DIADIEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAPKHO> PHIEUNHAPKHOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHANHLI> PHIEUTHANHLIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXUATKHO> PHIEUXUATKHOes { get; set; }
    }
}
