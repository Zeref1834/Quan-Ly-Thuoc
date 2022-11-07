namespace QuanLyBanThuoc.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUOC")]
    public partial class THUOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUOC()
        {
            LOTHUOCs = new HashSet<LOTHUOC>();
            PHIEUDATHANGs = new HashSet<PHIEUDATHANG>();
            PHIEUNHAPKHOes = new HashSet<PHIEUNHAPKHO>();
            PHIEUTHANHLIs = new HashSet<PHIEUTHANHLI>();
        }

        [Key]
        [StringLength(6)]
        public string MATHUOC { get; set; }

        [Required]
        [StringLength(200)]
        public string TENTHUOC { get; set; }

        [Required]
        [StringLength(6)]
        public string MADVT { get; set; }

        public int SOLUONG { get; set; }

        public int DONGIAMUA { get; set; }

        public int DONGIABAN { get; set; }

        [Required]
        [StringLength(6)]
        public string MALOAITHUOC { get; set; }

        public virtual DVTINH DVTINH { get; set; }

        public virtual LOAITHUOC LOAITHUOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOTHUOC> LOTHUOCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDATHANG> PHIEUDATHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAPKHO> PHIEUNHAPKHOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHANHLI> PHIEUTHANHLIs { get; set; }
    }
}
