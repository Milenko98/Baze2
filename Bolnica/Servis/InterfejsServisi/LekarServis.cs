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
    public class LekarServis : ILekar
    {

        public LekarServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Lekar> dbSet = db.Set<Lekar>();
                    Lekar entityToDelete = db.Set<Lekar>().Find(id);
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

        public virtual Lekar FindById(object id)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Lekar>().Find(id);
            }
        }

        public virtual List<Lekar> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Lekar>().ToList();
            }
        }

        public bool Insert(Lekar entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Lekar>().Add(entity);
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

        public bool Update(Lekar entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Lekar>().Attach(entityToUpdate);
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

        public Lekar FindByName(string name)
        {
            using (var db = new Model1Container())
            {
                var pom = db.Set<Lekar>().First(f => f.Ime == name);
                return pom;
            }
        }

        public bool DeleteBolnica(int id)
        {
            List<Lekar> lista = new List<Lekar>();
            PregledaServis ps = new PregledaServis();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Lekar>().Where(x => x.BolnicaOznaka_B == id).ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            ps.DeleteLekar(v.Jmbg);
                            db.Set<Lekar>().Remove(v);
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
            List<Lekar> lista = new List<Lekar>();
            PregledaServis ps = new PregledaServis();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Lekar>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if (v.BolnicaOznaka_B == id)
                            {
                                ps.DeleteLekar(v.Jmbg);
                                db.Set<Lekar>().Remove(v);
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
            List<Lekar> lista = new List<Lekar>();
            PregledaServis ps = new PregledaServis();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Lekar>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if (v.MestoP_Broj == id)
                            {
                                ps.DeleteLekar(v.Jmbg);
                                db.Set<Lekar>().Remove(v);
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
