//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servis.Baza
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pregled
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pregled()
        {
            this.Uspostavljas = new HashSet<Uspostavlja>();
            this.Pregledas = new HashSet<Pregleda>();
            this.Dolazis = new HashSet<Dolazi>();
        }
    
        public int Broj_P { get; set; }
        public string Naziv { get; set; }
        public string Ime_pacijenta { get; set; }
        public string Prezime_pacijenta { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uspostavlja> Uspostavljas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregleda> Pregledas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dolazi> Dolazis { get; set; }
    }
}
