namespace web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        public int MaHD { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        public int? TongTien { get; set; }

        [StringLength(50)]
        public string DiaChiShip { get; set; }

        public int? Status { get; set; }
    }
}
