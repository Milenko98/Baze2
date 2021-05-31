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
    public class OsobaServis : IOsoba
    {
        public OsobaServis()
        {

        }

        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Osoba> dbSet = db.Set<Osoba>();
                    Osoba entityToDelete = db.Set<Osoba>().Find(id);
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

        public virtual Osoba FindById(object id)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Osoba>().Find(id);
            }
        }

        public virtual List<Osoba> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Osoba>().ToList();
            }
        }

        public bool Insert(Osoba entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Osoba>().Add(entity);
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

        public bool Update(Osoba entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Osoba>().Attach(entityToUpdate);
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
                var pom = db.Set<Osoba>().First(f => f.Ime == name);
                return pom.Jmbg;
            }
        }
    }
}
