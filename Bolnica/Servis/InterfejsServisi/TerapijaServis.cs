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
    public class TerapijaServis : ITerapija
    {

        public TerapijaServis()
        {

        }

        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Terapija> dbSet = db.Set<Terapija>();
                    Terapija entityToDelete = db.Set<Terapija>().Find(id);
                    db.Set<Terapija>().Remove(entityToDelete);
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

        public virtual Terapija FindById(object id)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Terapija>().Find(id);
            }
        }

        public virtual List<Terapija> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Terapija>().ToList();
            }
        }

        public bool Insert(Terapija entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Terapija>().Add(entity);
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

        public bool Update(Terapija entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Terapija>().Attach(entityToUpdate);
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
                var pom = db.Set<Terapija>().First(f => f.Naziv == name);
                return pom.Broj_T;
            }
        }
    }
}
