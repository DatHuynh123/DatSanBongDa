namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loaisan")]
    public partial class Loaisan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLS { get; set; }

        [StringLength(50)]
        public string TenLS { get; set; }

        [StringLength(50)]
        public string TTLS { get; set; }
    }
}
