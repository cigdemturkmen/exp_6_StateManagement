using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exp_6_StateManagement.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string EPosta { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Parola { get; set; }
    }
}