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
    public class SadrziServis : ISadrzi
    {

        public SadrziServis() { }
        public virtual bool Delete(object id1, object id2)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Sadrzi> dbSet = db.Set<Sadrzi>();
                    Sadrzi entityToDelete = db.Set<Sadrzi>().Find(id1, id2);
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

        public virtual Sadrzi FindById(object id1)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Sadrzi>().Find(id1);
            }
        }

        public virtual List<Sadrzi> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Sadrzi>().ToList();
            }
        }

        public bool Insert(Sadrzi entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Sadrzi>().Add(entity);
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

        public bool Update(Sadrzi entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Sadrzi>().Attach(entityToUpdate);
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

        public bool DeleteDijagnoza(int id)
        {
            List<Sadrzi> lista = new List<Sadrzi>();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Sadrzi>().Where(x => x.DijagnozaOznaka_D == id).ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            db.Set<Sadrzi>().Remove(v);
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

        public bool DeleteZdravstveniKarton(int id)
        {
            List<Sadrzi> lista = new List<Sadrzi>();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Sadrzi>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if(v.ZdravstveniKartonBroj_K == id)
                                db.Set<Sadrzi>().Remove(v);
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
