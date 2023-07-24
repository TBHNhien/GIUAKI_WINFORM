namespace QLSV.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SINHVIEN")]
    public partial class SINHVIEN
    {
        [Key]
        [StringLength(6)]
        public string MASV { get; set; }

        [StringLength(40)]
        public string HOTENSV { get; set; }

        public DateTime? NGAYSINH { get; set; }

        [StringLength(3)]
        public string MALOP { get; set; }

        public virtual LOP LOP { get; set; }
    }
}
