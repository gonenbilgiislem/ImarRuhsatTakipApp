//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImarRuhsatTakipApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Yetkiler
    {
        public int Id { get; set; }
        public int Kullanicilar_Id { get; set; }
        public int Basvuru_Turleri_Id { get; set; }
    
        public virtual Basvuru_Turleri Basvuru_Turleri { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
