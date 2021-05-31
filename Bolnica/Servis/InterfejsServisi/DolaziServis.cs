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
    public class DolaziServis : IDolazi
    {

        public DolaziServis() { }
        public virtual bool Delete(object id1, object id2)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Dolazi> dbSet = db.Set<Dolazi>();
                    Dolazi entityToDelete = db.Set<Dolazi>().Find(id1, id2);
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

        public virtual Dolazi FindById(object id1)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Dolazi>().Find(id1);
            }
        }

        public virtual List<Dolazi> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Dolazi>().ToList();
            }
        }

        public bool Insert(Dolazi entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Dolazi>().Add(entity);
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

        public bool Update(Dolazi entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Dolazi>().Attach(entityToUpdate);
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
