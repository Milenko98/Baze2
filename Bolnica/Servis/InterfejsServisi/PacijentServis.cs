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
    public class PacijentServis : IPacijent
    {
        public PacijentServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Pacijent> dbSet = db.Set<Pacijent>();
                    Pacijent entityToDelete = db.Set<Pacijent>().Find(id);
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

        public virtual Pacijent FindById(object id)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Pacijent>().Find(id);
            }
        }

        public virtual List<Pacijent> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Pacijent>().ToList();
            }
        }

        public bool Insert(Pacijent entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Pacijent>().Add(entity);
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

        public bool Update(Pacijent entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Pacijent>().Attach(entityToUpdate);
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
        public Pacijent FindByName(string name)
        {
            using (var db = new Model1Container())
            {
                var pom = db.Set<Pacijent>().First(f => f.Ime == name);
                return pom;
            }
        }

        public bool DeleteBolnica(int id)
        {
            List<Pacijent> lista = new List<Pacijent>();
            ZdravstveniKartonServis zks = new ZdravstveniKartonServis();
            DolaziServis ds = new DolaziServis();
            bool b1 = false;
            bool b2 = false;
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Pacijent>().Where(x => x.BolnicaOznaka_B == id).ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if (zks.DeletePacijent(v.Jmbg))
                                b1 = true;
                            if (ds.DeletePacijent(v.Jmbg))
                                b2 = true;
                            if(b1 || b2)
                                db.Set<Pacijent>().Remove(v);
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

        public bool DeleteMesto(int id)
        {
            List<Pacijent> lista = new List<Pacijent>();
            ZdravstveniKartonServis zks = new ZdravstveniKartonServis();
            DolaziServis ds = new DolaziServis();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Pacijent>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if (v.BolnicaOznaka_B == id)
                            {
                                zks.DeletePacijent(v.Jmbg);
                                ds.DeletePacijent(v.Jmbg);
                                db.Set<Pacijent>().Remove(v);
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

        public bool DeleteMestoo(int id)
        {
            List<Pacijent> lista = new List<Pacijent>();
            ZdravstveniKartonServis zks = new ZdravstveniKartonServis();
            DolaziServis ds = new DolaziServis();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Pacijent>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if (v.MestoP_Broj == id)
                            {
                                zks.DeletePacijent(v.Jmbg);
                                ds.DeletePacijent(v.Jmbg);
                                db.Set<Pacijent>().Remove(v);
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
