using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Models;

namespace web.Models
{
    public class Search
    {
        Model1 db = new Model1();
        public List<Product> SearchByKey(string key)
        {
            return db.Products.SqlQuery("Select * from Product Where ProductName like '%" + key + "%'").ToList();
        }
    }
}