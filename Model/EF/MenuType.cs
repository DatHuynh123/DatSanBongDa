namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuType")]
    public partial class MenuType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaMNT { get; set; }

        public int? IDMNT { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual User User { get; set; }
    }
}
