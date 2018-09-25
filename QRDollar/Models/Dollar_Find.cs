namespace QRDollar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dollar_Find
    {
        public int Id { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Photo { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public DbGeography GPS { get; set; }
    }
}
