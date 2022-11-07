namespace QuanLyBanThuoc.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HT_THANHTOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HT_THANHTOAN()
        {
            PHIEUDATHANGs = new HashSet<PHIEUDATHANG>();
        }

        [Key]
        [StringLength(6)]
        public string MAHT { get; set; }

        [Required]
        [StringLength(100)]
        public string TENHT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDATHANG> PHIEUDATHANGs { get; set; }
    }
}
