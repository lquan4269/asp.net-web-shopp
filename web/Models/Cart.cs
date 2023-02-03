using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class Cart
    {
        public int MaSP { get; set; }
        public string Ten { get; set; }
        public int Gia { get; set; }
        public int SoLuong { get; set; }
        public string Description { get; set; }
        public int ThanhTien { get { return Gia * SoLuong; } }
    }
}