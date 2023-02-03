namespace web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Product_ID { get; set; }

        [StringLength(50)]
        public string Product_name { get; set; }

        public float? Product_price { get; set; }

        public int? Product_Type { get; set; }

        [StringLength(100)]
        public string Product_images { get; set; }
    }
}
