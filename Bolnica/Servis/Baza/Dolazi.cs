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
    
    public partial class Dolazi
    {
        public int PacijentJmbg { get; set; }
        public int PregledBroj_P { get; set; }
    
        public virtual Pacijent Pacijent { get; set; }
        public virtual Pregled Pregled { get; set; }
    }
}
