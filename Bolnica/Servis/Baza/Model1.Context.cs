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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bolnica> Bolnicas { get; set; }
        public virtual DbSet<Mesto> Mestoes { get; set; }
        public virtual DbSet<Osoba> Osobas { get; set; }
        public virtual DbSet<ZdravstveniKarton> ZdravstveniKartons { get; set; }
        public virtual DbSet<Dijagnoza> Dijagnozas { get; set; }
        public virtual DbSet<Lek> Leks { get; set; }
        public virtual DbSet<Terapija> Terapijas { get; set; }
        public virtual DbSet<Lecenje> Lecenjes { get; set; }
        public virtual DbSet<Pregled> Pregleds { get; set; }
        public virtual DbSet<Uspostavlja> Uspostavljas { get; set; }
        public virtual DbSet<Recept> Recepts { get; set; }
        public virtual DbSet<SeLeci> SeLecis { get; set; }
        public virtual DbSet<Sadrzi> Sadrzis { get; set; }
        public virtual DbSet<Poseduje> Posedujes { get; set; }
        public virtual DbSet<Izdaje> Izdajes { get; set; }
        public virtual DbSet<Dolazi> Dolazis { get; set; }
        public virtual DbSet<Pregleda> Pregledas { get; set; }
    }
}
