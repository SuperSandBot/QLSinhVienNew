namespace QLSinhVien.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [Key]
        [StringLength(10)]
        public string MSSV { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        public double DTB { get; set; }

        [Required]
        [StringLength(10)]
        public string KhoaID { get; set; }

        public virtual Khoa Khoa { get; set; }
    }
}
