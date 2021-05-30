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
    public class DijagnozaServis : IDijagnoza
    {
        public DijagnozaServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    DbSet<Dijagnoza> dbSet = db.Set<Dijagnoza>();
                    Dijagnoza entityToDelete = db.Set<Dijagnoza>().Find(id);
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

        public virtual Dijagnoza FindById(object id)
        {

            using (var db = new Model1Container1())
            {
                return db.Set<Dijagnoza>().Find(id);
            }
        }

        public virtual List<Dijagnoza> GetAll()
        {
            using (var db = new Model1Container1())
            {
                return db.Set<Dijagnoza>().ToList();
            }
        }

        public bool Insert(Dijagnoza entity)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    db.Set<Dijagnoza>().Add(entity);
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

        public bool Update(Dijagnoza entityToUpdate)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    db.Set<Dijagnoza>().Attach(entityToUpdate);
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
            using (var db = new Model1Container1())
            {
                var pom = db.Set<Dijagnoza>().First(f => f.Naziv == name);
                return pom.Oznaka_D;
            }
        }

        public Dijagnoza FindByNamee(string name)
        {
            using (var db = new Model1Container1())
            {
                var pom = db.Set<Dijagnoza>().First(f => f.Naziv == name);
                return pom;
            }
        }
    }
}
