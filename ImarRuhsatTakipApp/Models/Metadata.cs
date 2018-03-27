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

    public class BasvuruMetadata
    {
        [Required]
        [Display(Name = "Başvuru Türü (İskan ? Ruhsat) ")]
        public string Basvuru_Turleri_Id;

        [Required]
        [Display(Name = "Referans Kodu ")]
        public Int64 Referans_kod;

        [Required]
        [Display(Name = "Yapı Denetim Firması ")]
        public string Yapi_Denetim_Firmasi_Id;

        [Required]
        [Display(Name = "Mal Sahibi Adı Soyadı ")]
        public string Mal_Sahibi_Ad_Soyad;

        [Required]
        [Display(Name = "Müteahhit Adı Soyadı ")]
        public string Muteahhit_Id;

        [Required]
        [Display(Name = "Talep Tipi (Alındı vs.) ")]
        public string Talep_Tipleri_Id;

        [Required]
        [Display(Name = "Durum (İşbitirme vs.)")]
        public string Durum_Id;

        [Required]
        [Display(Name = "Açıklama - Notlar ")]
        public string Aciklama;

        [Required]
        [Display(Name = "Kaydeden ")]
        public string Kullanicilar_Id;

        //[Required]
        //[Display(Name = "Dilekçe Tarihi ")]
        //public Nullable<System.DateTime> Dilekce_Tarihi;
    }
}