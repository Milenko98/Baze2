using Servis.Baza;
using Servis.Interfejsi;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.InterfejsServisi
{
    public class BolnicaServis : IBolnica
    {
        public BolnicaServis()
        {

        }

        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Bolnica> dbSet = db.Set<Bolnica>();
                    Bolnica entityToDelete = db.Set<Bolnica>().Find(id);
                    db.Entry(entityToDelete).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Message:\n" + e.Message);
                    return false;
                }

            }
        }

        public virtual Bolnica FindById(object id)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Bolnica>().Find(id);
            }
        }

        public virtual List<Bolnica> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Bolnica>().ToList();
            }
        }

        public bool Insert(Bolnica entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Bolnica>().Add(entity);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Message:\n" + e.Message);
                    return false;
                }

            }
        }

        public bool Update(Bolnica entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Bolnica>().Attach(entityToUpdate);
                    db.Entry(entityToUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Message:\n" + e.Message);
                    return false;
                }

            }
        }

        public int FindByName(string name)
        {
            using (var db = new Model1Container())
            {
                var pom = db.Set<Bolnica>().First(f => f.Naziv == name);
                return pom.Oznaka_B;
            }
        }

        public bool Validate(string name)
        {
            using (var db = new Model1Container())
            {
                if (db.Set<Bolnica>().FirstOrDefault(f => f.Naziv == name) != null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool DeleteMesto(int id)
        {
            List<Bolnica> lista = new List<Bolnica>();
            PacijentServis ps = new PacijentServis();
            LekarServis ls = new LekarServis();
            RecepcionerServis rs = new RecepcionerServis();
            ObezbedjenjeServis os = new ObezbedjenjeServis();
            OsobaServis oos = new OsobaServis();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Bolnica>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if (v.MestoP_Broj == id)
                            {
                                ps.DeleteMesto(v.Oznaka_B);
                                ls.DeleteMesto(v.Oznaka_B);
                                rs.DeleteMesto(v.Oznaka_B);
                                os.DeleteMesto(v.Oznaka_B);
                                db.Set<Bolnica>().Remove(v);
   
                            }
                        }
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Message:\n" + e.Message);
                    return false;
                }
            }
        }
    }
}
