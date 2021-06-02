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
    public class UspostavljaServis : IUspostavlja
    {

        public UspostavljaServis() { }
        public virtual bool Delete(object id1, object id2)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Uspostavlja> dbSet = db.Set<Uspostavlja>();
                    Uspostavlja entityToDelete = db.Set<Uspostavlja>().Find(id1,id2);
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

        public virtual Uspostavlja FindById(object id1, object id2)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Uspostavlja>().Find(id1,id2);
            }
        }

        public virtual List<Uspostavlja> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Uspostavlja>().ToList();
            }
        }

        public bool Insert(Uspostavlja entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Uspostavlja>().Add(entity);
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

        public bool Update(Uspostavlja entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Uspostavlja>().Attach(entityToUpdate);
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

        public bool DeleteLecenje(int id1, int id2)
        {
            List<Uspostavlja> lista = new List<Uspostavlja>();
            IzdajeServis izs = new IzdajeServis();
            using (var db = new Model1Container())
            {
                try
                {

                    lista = db.Set<Uspostavlja>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if (v.LecenjeDijagnozaOznaka_D == id1 && v.LecenjeTerapijaBroj_T == id2)
                            {
                                izs.DeleteUspostavlja(v.DijagnozaOznaka_D, v.PregledBroj_P);
                                db.Set<Uspostavlja>().Remove(v);
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

        public bool DeletePregled(int id)
        {
            List<Uspostavlja> lista = new List<Uspostavlja>();
            IzdajeServis izs = new IzdajeServis();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Uspostavlja>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if (v.PregledBroj_P == id)
                            {
                                izs.DeleteUspostavlja(v.DijagnozaOznaka_D, v.PregledBroj_P);
                                db.Set<Uspostavlja>().Remove(v);
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

        public bool DeleteDijagnoza(int id)
        {
            List<Uspostavlja> lista = new List<Uspostavlja>();
            IzdajeServis izs = new IzdajeServis();
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<Uspostavlja>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if (v.DijagnozaOznaka_D == id)
                            {
                                izs.DeleteUspostavlja(v.DijagnozaOznaka_D, v.PregledBroj_P);
                                db.Set<Uspostavlja>().Remove(v);
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
