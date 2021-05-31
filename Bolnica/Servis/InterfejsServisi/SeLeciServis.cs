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
    public class SeLeciServis : ISeLeci
    {

        public SeLeciServis() { }
        public virtual bool Delete(object id1, object id2)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<SeLeci> dbSet = db.Set<SeLeci>();
                    SeLeci entityToDelete = db.Set<SeLeci>().Find(id1, id2);
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

        public virtual SeLeci FindById(object id1)
        {

            using (var db = new Model1Container())
            {
                return db.Set<SeLeci>().Find(id1);
            }
        }

        public virtual List<SeLeci> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<SeLeci>().ToList();
            }
        }

        public bool Insert(SeLeci entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<SeLeci>().Add(entity);
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

        public bool Update(SeLeci entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<SeLeci>().Attach(entityToUpdate);
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
