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
    public class PregledaServis : IPregleda
    {

        public PregledaServis() { }
        public virtual bool Delete(object id1, object id2)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Pregleda> dbSet = db.Set<Pregleda>();
                    Pregleda entityToDelete = db.Set<Pregleda>().Find(id1, id2);
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

        public virtual Pregleda FindById(object id1)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Pregleda>().Find(id1);
            }
        }

        public virtual List<Pregleda> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Pregleda>().ToList();
            }
        }

        public bool Insert(Pregleda entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Pregleda>().Add(entity);
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

        public bool Update(Pregleda entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Pregleda>().Attach(entityToUpdate);
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
