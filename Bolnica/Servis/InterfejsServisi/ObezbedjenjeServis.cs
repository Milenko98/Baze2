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
    public class ObezbedjenjeServis : IObezbedjenje
    {
        public ObezbedjenjeServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    DbSet<Obezbedjenje> dbSet = db.Set<Obezbedjenje>();
                    Obezbedjenje entityToDelete = db.Set<Obezbedjenje>().Find(id);
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

        public virtual Obezbedjenje FindById(object id)
        {

            using (var db = new Model1Container1())
            {
                return db.Set<Obezbedjenje>().Find(id);
            }
        }

        public virtual List<Obezbedjenje> GetAll()
        {
            using (var db = new Model1Container1())
            {
                return db.Set<Obezbedjenje>().ToList();
            }
        }

        public bool Insert(Obezbedjenje entity)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    db.Set<Obezbedjenje>().Add(entity);
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

        public bool Update(Obezbedjenje entityToUpdate)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    db.Set<Obezbedjenje>().Attach(entityToUpdate);
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
