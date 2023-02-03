namespace web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public short ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public float? Price { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Origin { get; set; }

        public int? Type { get; set; }
    }
}
