using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIUnity.Models
{
    public class Uyeler
    {
        [Key]
        public int Id { get; set; }
        public string kullaniciAdi { get; set; }
        public string parola { get; set; }
    }
}