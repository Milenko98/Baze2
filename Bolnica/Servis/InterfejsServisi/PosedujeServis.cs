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
    public class PosedujeServis : IPoseduje
    {

        public PosedujeServis() { }
        public virtual bool Delete(object id1, object id2)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Poseduje> dbSet = db.Set<Poseduje>();
                    Poseduje entityToDelete = db.Set<Poseduje>().Find(id1, id2);
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

        public virtual Poseduje FindById(object id1)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Poseduje>().Find(id1);
            }
        }

        public virtual List<Poseduje> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Poseduje>().ToList();
            }
        }

        public bool Insert(Poseduje entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Poseduje>().Add(entity);
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

        public bool Update(Poseduje entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Poseduje>().Attach(entityToUpdate);
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

        public bool DeleteTerapija(int id)
        {
            List<Poseduje> lista = new List<Poseduje>();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Poseduje>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if (v.TerapijaBroj_T == id)
                            {
                                db.Set<Poseduje>().Remove(v);
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

        public bool DeleteZdravstveniKarton(int id)
        {
            List<Poseduje> lista = new List<Poseduje>();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Poseduje>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if(v.ZdravstveniKartonBroj_K == id)
                                db.Set<Poseduje>().Remove(v);
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
