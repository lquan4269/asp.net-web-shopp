using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        Model1 db = new Model1();
        public ActionResult Index()
        {
            var cart = Session["Cart"];
            var listItem = new List<Cart>();
            if (cart != null) {
                listItem = (List<Cart>)cart;
            }
            return View(listItem);
        }
        public ActionResult AddItem(int id, int soluong, string name, int gia, string description)
        {
            var cart = Session["Cart"];
            if (cart != null)
            {
                var listItem = new List<Cart>();
                if (listItem.Exists(x => x.MaSP == id))
                {
                    foreach (var item in listItem)
                    {
                        if (item.MaSP == id)
                        {
                            item.SoLuong += soluong;
                        }
                    }
                }
                else
                {
                    var item = new Cart();
                    item.MaSP = id;
                    item.SoLuong = soluong;
                    item.Gia = gia;
                    item.Ten = name;
                    item.Description = description;
                    listItem.Add(item);
                }
                Session["Cart"] = listItem;
            }
            else
            {
                var item = new Cart();
                item.MaSP = id;
                item.SoLuong = soluong;
                item.Gia = gia;
                item.Ten = name;
                item.Description = description;
                var listItem = new List<Cart>();
                listItem.Add(item);
                Session["Cart"] = listItem;
            }
            return RedirectToAction("Index","Cart");
        }
        public ActionResult Update_Quantity_Cart(int id, int soluong)
        {
            List<Cart> cart = Session["Cart"] as List<Cart>;
            Cart UpdateCart = cart.FirstOrDefault(x => x.MaSP == id); //FirstOrDefault linq giá trị mặc định khác null
            if (UpdateCart != null)
            {
                UpdateCart.SoLuong = soluong;
            }
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult RemoveCart(int id)
        {
            List<Cart> cart = Session["Cart"] as List<Cart>;
            Cart deletecart = cart.FirstOrDefault(x => x.MaSP == id);
            if (deletecart != null)
            {
                cart.Remove(deletecart);
            }
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult ThanhToan()
        {
            var cart = Session["Cart"];
            var listItem = new List<Cart>();
            if (cart != null)
            {
                listItem = (List<Cart>)cart;
            }
            return View(listItem);
        }
        public ActionResult CheckOut(FormCollection form)
        {
            int total = 0;
            List<Cart> listcart = Session["Cart"] as List<Cart>;
            foreach (Cart cart in listcart)
            {
                total += cart.SoLuong * cart.Gia;
            }
            Order bill = new Order()
            {
                
                TenKH = form["customerName"],
                DiaChiShip = form["diachi"],
                Date = DateTime.Now,
                Status = 0,
                TongTien = total
            };
           // 2 câu truy vấn kề nhau chạy 2 lần (đóng gói trong 1 trainstion)
            db.Orders.Add(bill);
            db.SaveChanges();
            foreach (Cart cart in listcart)
            {
                OrderDetail billDetail = new OrderDetail()
                {
                    MaHD = bill.MaHD,
                    MaSP = cart.MaSP,
                    Quantity = cart.SoLuong,
                    price = cart.Gia

                };
                db.OrderDetails.Add(billDetail);
                db.SaveChanges();
            }
            Session.Remove("Cart");
            return View(bill);
        }
    }
}