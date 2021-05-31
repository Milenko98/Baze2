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
    public class PregledServis : IPregled
    {

        public PregledServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Pregled> dbSet = db.Set<Pregled>();
                    Pregled entityToDelete = db.Set<Pregled>().Find(id);
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

        public virtual Pregled FindById(object id)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Pregled>().Find(id);
            }
        }

        public virtual List<Pregled> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Pregled>().ToList();
            }
        }

        public bool Insert(Pregled entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Pregled>().Add(entity);
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

        public bool Update(Pregled entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Pregled>().Attach(entityToUpdate);
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
                var pom = db.Set<Pregled>().First(f => f.Naziv == name);
                return pom.Broj_P;
            }
        }

        public Pregled FindByNamee(string name)
        {
            using (var db = new Model1Container())
            {
                var pom = db.Set<Pregled>().First(f => f.Naziv == name);
                return pom;
            }
        }
    }
}
