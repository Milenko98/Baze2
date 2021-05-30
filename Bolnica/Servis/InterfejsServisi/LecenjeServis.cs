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
    public class LecenjeServis : ILecenje
    {

        public LecenjeServis() { }
        public virtual bool Delete(object id1, object id2)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    DbSet<Lecenje> dbSet = db.Set<Lecenje>();
                    Lecenje entityToDelete = db.Set<Lecenje>().Find(id1, id2);
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

        public virtual Lecenje FindById(object id1, object id2)
        {

            using (var db = new Model1Container1())
            {
                return db.Set<Lecenje>().Find(id1, id2);
            }
        }

        public virtual List<Lecenje> GetAll()
        {
            using (var db = new Model1Container1())
            {
                return db.Set<Lecenje>().ToList();
            }
        }

        public bool Insert(Lecenje entity)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    db.Set<Lecenje>().Add(entity);
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

        public bool Update(Lecenje entityToUpdate)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    db.Set<Lecenje>().Attach(entityToUpdate);
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
