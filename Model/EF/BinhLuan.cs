namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaBL { get; set; }

        [StringLength(10)]
        public string MaSan { get; set; }

        public int? MaKH { get; set; }

        public int? MaTV { get; set; }

        [StringLength(350)]
        public string NoiDung { get; set; }

        public virtual khachhang khachhang { get; set; }

        public virtual San San { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
