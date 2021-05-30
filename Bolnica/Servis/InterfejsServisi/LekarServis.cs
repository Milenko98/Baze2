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
    public class LekarServis : ILekar
    {

        public LekarServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    DbSet<Lekar> dbSet = db.Set<Lekar>();
                    Lekar entityToDelete = db.Set<Lekar>().Find(id);
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

        public virtual Lekar FindById(object id)
        {

            using (var db = new Model1Container1())
            {
                return db.Set<Lekar>().Find(id);
            }
        }

        public virtual List<Lekar> GetAll()
        {
            using (var db = new Model1Container1())
            {
                return db.Set<Lekar>().ToList();
            }
        }

        public bool Insert(Lekar entity)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    db.Set<Lekar>().Add(entity);
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

        public bool Update(Lekar entityToUpdate)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    db.Set<Lekar>().Attach(entityToUpdate);
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
