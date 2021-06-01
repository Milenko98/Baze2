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
    public class IzdajeServis : IIzdaje
    {

        public IzdajeServis() { }
        public virtual bool Delete(object id1, object id2, object id3)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Izdaje> dbSet = db.Set<Izdaje>();
                    Izdaje entityToDelete = db.Set<Izdaje>().Find(id1, id2, id3);
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

        public virtual Izdaje FindById(object id1)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Izdaje>().Find(id1);
            }
        }

        public virtual List<Izdaje> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Izdaje>().ToList();
            }
        }

        public bool Insert(Izdaje entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Izdaje>().Add(entity);
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

        public bool Update(Izdaje entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Izdaje>().Attach(entityToUpdate);
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

        public bool DeleteRecept(int id)
        {
            List<Izdaje> lista = new List<Izdaje>();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Izdaje>().Where(x => x.ReceptOznaka_R == id).ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            db.Set<Izdaje>().Remove(v);
                        }
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("Message:\n" + e.Message);
                    return false;
                }
            }
        }

        public bool DeleteUspostavlja(int id1, int id2)
        {
            List<Izdaje> lista = new List<Izdaje>();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Izdaje>().Where(x => x.UspostavljaDijagnozaOznaka_D == id1 && x.UspostavljaPregledBroj_P == id2).ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            db.Set<Izdaje>().Remove(v);
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
