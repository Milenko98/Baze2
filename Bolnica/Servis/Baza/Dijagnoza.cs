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
    
    public partial class Dijagnoza
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dijagnoza()
        {
            this.ZdravstveniKartons = new HashSet<ZdravstveniKarton>();
            this.Leks = new HashSet<Lek>();
            this.Lecenjes = new HashSet<Lecenje>();
            this.Uspostavljas = new HashSet<Uspostavlja>();
        }
    
        public int Oznaka_D { get; set; }
        public string Naziv { get; set; }
        public int UspostavljaPregledBroj_P { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZdravstveniKarton> ZdravstveniKartons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lek> Leks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lecenje> Lecenjes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uspostavlja> Uspostavljas { get; set; }
    }
}
