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
    
    public partial class Muteahhit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Muteahhit()
        {
            this.Basvuru = new HashSet<Basvuru>();
        }
    
        public int Mutheahhit_Id { get; set; }
        public string Mutheahhit_Ad_Soyad { get; set; }
        public string Mutheahhit_Firma_Adi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basvuru> Basvuru { get; set; }
    }
}
