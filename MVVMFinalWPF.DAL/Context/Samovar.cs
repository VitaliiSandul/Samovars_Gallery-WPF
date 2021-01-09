namespace MVVMFinalWPF.DAL.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Samovar")]
    public partial class Samovar
    {
        public int Id { get; set; }

        public int? ManufacturerId { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        public int Volume { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
