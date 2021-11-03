using exp_6_StateManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_6_StateManagement.Controllers
{
    public class HomeController : Controller
    {

        /*
         State Management: Durum Yönetimi(mülakat sorusu) //

        1. Client side state management (istemci - tarayıcı arayıcılığıyla- tarayıcısında veri tutma yöntemleri)
          a. Hidden field : <input type="hidden" value="10" />
          b. Cookie : Kullanıcının tarayıcısında veri tutmayı sağlar. //sayfadan sayfaya veri taşır.(aşağıda index'ten login.cshtml'ye username ve psw taşıdı)
          c. Query String: url'den veri taşımak/tutmak için kullanırız () // sayfadan sayfaya ver taşır.

        2. Server side state management 
          a. Session (oturum) : 20dk(default) timeout. Oturumu kapat demesen de 20 dk'da oturumun kapanması.ya da uygulamayı kapatırsanız mevcut sessionlar kapatıır.her sessionda bir id oluşuyor. web.config içinde timeout değiştirilebilir(dk cinsinden).

        <system.web> <sessionState = timeout ="10" /> bu kısım eklenir. </system.web>

          b. Application : Proje çalıştığında application nesneleri oluşur. timeout vb. yoktur; projeyi kapatana kadar yaşarlar. proje kapatıldığında RAM'den silinir.



         */


        #region Cookie
        
        public ActionResult Index()
        {
            #region Cookie set etmek
            //if ("beni hatırla" checkbox'ı checklendiyse çerez oluştur)
            //{
            //aşağıdaki kodlar buraya konur.. çerez kaydetmek için sormak zorundasın kullanıcıya, new law.
            //}
            var cerez = new HttpCookie("loginbilgileri");
            cerez.Expires = DateTime.Now.AddDays(10);  //expire ve domain propertyleri zorunlu değil. yazılmazsa çerez sonsuza kadar tutulur.
            //cerez.Domain = "www.bilgeadam.com"; sadece bu domande aktif olur.
            cerez.Values.Add("kullaniciAdi", "nur.ozturk");
            cerez.Values.Add("parola", "123456"); // hasleyip tut bunu. hash, crypto

            HttpContext.Response.Cookies.Add(cerez); //http isteğine cevap olarak göndermen lazım!
            #endregion

            return View();
        }

        public ActionResult Login()// login action'ı normalde  AuthController'ın içinde olur.
        {
            #region Tarayıcıdan cookie bilgisini alma

            var gelenCerez = HttpContext.Request.Cookies["loginBilgileri"]; // Cookies.Get("loginBilgileri") diye metot şeklinde de yazabilirsin.

            if (gelenCerez != null)
            {
                var userName = gelenCerez.Values.Get("kullaniciAdi");
                var password = gelenCerez.Values["parola"]; //Index'iyle değil adıyla çekmen daha iyi (gelenCerez.Values[1] yerine Values["parola"] )
            }
            #endregion
            return View();
        }
        #endregion

        #region Query String

        //public ActionResult Hakkimizda ()
        //{ 1.yöntem
        //    var isim = HttpContext.Request.QueryString["ad"];
        //    var soyisim = HttpContext.Request.QueryString.Get("soyad");
        //    var yas = HttpContext.Request.QueryString.Get("yas");

        //    return View();
        //}

        //2.yöntem
        public ActionResult Hakkimizda(string ad, string soyad, int yas)
        {
            return View();
        }
        #endregion


        #region Session
        //e ticaretteki sepet olayı...serverın ram üzerinde tutuluyor. uygulama kapatıldığında hala seppetekiler duruyosa db'ye atılmış demektir.
        // kullanıcı oturumu

        public ActionResult OturumAc()
        {
            // kullanıcın ekranda username ve passwordünü alarak bunun dbden var olup olmadığını sorgularız.
            // giriş ve kullanıcının ihtiyaç duyulan bilgileri session üzerine atılır.

            //var mevcutKullanici = _db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == model.KullaniciAdi && x.Parola == model.Parola );  DB'den çekseydik.
            var mevcutKullanici = new Kullanici()
            {
                Id=10,
                Ad= "Nur",
                Soyad="Öztürk",
                KullaniciAdi="nur.ozturk",
                EPosta="laks@aklsd.com",
                Parola="123456",
                DogumTarihi= new DateTime(1991, 6, 2)
            };

            Session["Kullanici"] = mevcutKullanici;  // Session.Add("Kullanici", mevcutKullanici);

            return View();
        }
        #endregion


        #region Application

        public ActionResult Ornek1()
        {
            // bir değerin application'a set edilmesi
            HttpContext.Application.Add("ziyaretciSayisi", 0);
            HttpContext.Application["VersiyonBilgisi", "v.1.0.1"];

            // değerin application'dan alınması
            var ziyaretciSayisi = HttpContext.Application["ziyaretciSayisi"];
           


            if (ziyaretciSayisi != null)
            {
                var ziyaretciSayisiInt = Convert.ToInt32(ziyaretciSayisi);
            }
            return View();
        }
        #endregion
    }
}