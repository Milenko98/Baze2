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
    public class ObezbedjenjeServis : IObezbedjenje
    {
        public ObezbedjenjeServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Obezbedjenje> dbSet = db.Set<Obezbedjenje>();
                    Obezbedjenje entityToDelete = db.Set<Obezbedjenje>().Find(id);
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

        public virtual Obezbedjenje FindById(object id)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Obezbedjenje>().Find(id);
            }
        }

        public virtual List<Obezbedjenje> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Obezbedjenje>().ToList();
            }
        }

        public bool Insert(Obezbedjenje entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Obezbedjenje>().Add(entity);
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

        public bool Update(Obezbedjenje entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Obezbedjenje>().Attach(entityToUpdate);
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

        public bool DeleteBolnica(int id)
        {
            List<Obezbedjenje> lista = new List<Obezbedjenje>();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Obezbedjenje>().Where(x => x.BolnicaOznaka_B == id).ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            db.Set<Obezbedjenje>().Remove(v);
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
            List<Obezbedjenje> lista = new List<Obezbedjenje>();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Obezbedjenje>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if(v.BolnicaOznaka_B == id)
                                db.Set<Obezbedjenje>().Remove(v);
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
            List<Obezbedjenje> lista = new List<Obezbedjenje>();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Obezbedjenje>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if (v.MestoP_Broj == id)
                                db.Set<Obezbedjenje>().Remove(v);
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
