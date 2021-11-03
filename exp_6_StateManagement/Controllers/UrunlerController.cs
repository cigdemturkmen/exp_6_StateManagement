using exp_6_StateManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_6_StateManagement.Controllers
{
    public class UrunlerController : Controller
    {
        
        public ActionResult Index()
        {
            var mevcutKullaniciSession = Session["Kullanici"];

            if (mevcutKullaniciSession != null)
            {
                var oturumunuAcmisOlankullanici = (Kullanici)mevcutKullaniciSession; //session null değilse bu sayfaya girebilir.
                return View();
            }
            return RedirectToAction("OturumAc", "Home"); // ("Login", "Auth"); Autcontroller içindeki login'e yönlendir.
        }

        public ActionResult UrunEkle() // Actiona girmeden önce oturum var mı yok mu diye kontrol edip sonra sayfayı açtırma işini if yerine FİLTERlar ile yapabiliriz.
        {
            var mevcutKullaniciSession = Session["Kullanici"];

            if (mevcutKullaniciSession != null)
            {
                var oturumunuAcmisOlankullanici = (Kullanici)mevcutKullaniciSession; //session null değilse bu sayfaya girebilir.
                return View();
            }
            return RedirectToAction("OturumAc", "Home");
        }
    }
}