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
        [Display(Name = "Ad Soyad ")]
        public string Kullanici_Ad_Soyad;

        [Required]
        [Display(Name = "Şifre ")]
        [DataType(DataType.Password)]
        public string Sifre;
    }

    public class MuteahhitMetadata
    {
        [Required]
        [Display(Name = "Ad Soyad ")]
        public string Mutheahhit_Ad_Soyad;

        [Required]
        [Display(Name = "Firma Adı ")]
        public string Mutheahhit_Firma_Adi;
    }
}