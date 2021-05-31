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
                    //db.Set<Bolnica>().Remove(entityToDelete);
                    db.Entry(entityToDelete).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Message:\n" + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n" + e.InnerException);
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
                    Console.WriteLine("Message:\n" + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n" + e.InnerException);
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
                    Console.WriteLine("Message:\n" + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n" + e.InnerException);
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
    }
}
