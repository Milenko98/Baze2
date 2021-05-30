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
    public class ReceptServis : IRecept
    {
        public ReceptServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    DbSet<Recept> dbSet = db.Set<Recept>();
                    Recept entityToDelete = db.Set<Recept>().Find(id);
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

        public virtual Recept FindById(object id)
        {

            using (var db = new Model1Container1())
            {
                return db.Set<Recept>().Find(id);
            }
        }

        public virtual List<Recept> GetAll()
        {
            using (var db = new Model1Container1())
            {
                return db.Set<Recept>().ToList();
            }
        }

        public bool Insert(Recept entity)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    db.Set<Recept>().Add(entity);
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

        public bool Update(Recept entityToUpdate)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    db.Set<Recept>().Attach(entityToUpdate);
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
    }
}
