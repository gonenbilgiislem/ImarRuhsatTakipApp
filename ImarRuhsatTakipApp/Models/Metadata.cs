using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImarRuhsatTakipApp.Models
{
    public class KullanicilarMetadata
    {
        [Required]
        [Display(Name = "Ad Soyad 2")]
        public string Kullanici_Ad_Soyad;
    }
}