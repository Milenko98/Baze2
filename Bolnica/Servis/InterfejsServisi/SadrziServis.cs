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
    public class SadrziServis : ISadrzi
    {

        public SadrziServis() { }
        public virtual bool Delete(object id1, object id2)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Sadrzi> dbSet = db.Set<Sadrzi>();
                    Sadrzi entityToDelete = db.Set<Sadrzi>().Find(id1, id2);
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

        public virtual Sadrzi FindById(object id1)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Sadrzi>().Find(id1);
            }
        }

        public virtual List<Sadrzi> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Sadrzi>().ToList();
            }
        }

        public bool Insert(Sadrzi entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Sadrzi>().Add(entity);
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

        public bool Update(Sadrzi entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Sadrzi>().Attach(entityToUpdate);
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
