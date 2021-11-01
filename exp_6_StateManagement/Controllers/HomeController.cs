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
         State Management: Durum yönetimi(mülakat sorusu) //

        1.Client side state management (istemci - tarayıcı arayıcılığıyla- tarayıcısında veri tutma yöntemleri)
          a. Hidden field : <iput tyope="hidden valşue="10" />
          b. Cookie : Kullanıcının tarayıcısında veri tutmayı sağlar. //sayfadan sayfaya
          c. Query String: url'den veri taşımak/tutmak için () // sayfadan sayfaya

        2. Server side state management 

        a. Session
        b. Application

         
         */
        #region Cookie
        // GET: Home
        public ActionResult Index()
        {

            #region Cookie set etmek
            //if (beni hatırla seçildiyse çerez oluştur)
            //{
            //aşağıdaki kodlar.. çerez kaydetmek için sormak zorundasın kullanıcıya.
            //}
            var cerez = new HttpCookie("loginbilgileri");
            cerez.Expires = DateTime.Now.AddDays(10);  //expire ve domain zorunşu değil. yazılmazsa sonsuza kadar tutar.
            //cerez.Domain = "www.bilgeadam.com"; sadece bu domande aktif olur.
            cerez.Values.Add("kullaniciAdi", "nur.ozturk");
            cerez.Values.Add("parola", "123456");

            HttpContext.Response.Cookies.Add(cerez); //http isteğine cevap olarak göndermen lazım 
            #endregion
            return View();
        }

        public ActionResult Login()// login action'ı normalde auth Controller'ın içinde olur
        {
            #region Tarayıcıdan cookie bilgisini alma

            var gelenCerez = HttpContext.Request.Cookies["loginBilgileri"]; //cokies.get("")

            if (gelenCerez != null)
            {
                var userName = gelenCerez.Values.Get("kullaniciAdi");
                var password = gelenCerez.Values["parola"];  //indexiyle değil adıyla çekmen daha iyi. 
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
    }
}