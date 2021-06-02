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
    public class RecepcionerServis : IRecepcioner
    {
        public RecepcionerServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Recepcioner> dbSet = db.Set<Recepcioner>();
                    Recepcioner entityToDelete = db.Set<Recepcioner>().Find(id);
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

        public virtual Recepcioner FindById(object id)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Recepcioner>().Find(id);
            }
        }

        public virtual List<Recepcioner> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Recepcioner>().ToList();
            }
        }

        public bool Insert(Recepcioner entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Recepcioner>().Add(entity);
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

        public bool Update(Recepcioner entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Recepcioner>().Attach(entityToUpdate);
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
            List<Recepcioner> lista = new List<Recepcioner>();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Recepcioner>().Where(x => x.BolnicaOznaka_B == id).ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            db.Set<Recepcioner>().Remove(v);
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
            List<Recepcioner> lista = new List<Recepcioner>();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Recepcioner>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if(v.BolnicaOznaka_B == id)
                                db.Set<Recepcioner>().Remove(v);
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
            List<Recepcioner> lista = new List<Recepcioner>();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Recepcioner>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if (v.MestoP_Broj == id)
                                db.Set<Recepcioner>().Remove(v);
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
