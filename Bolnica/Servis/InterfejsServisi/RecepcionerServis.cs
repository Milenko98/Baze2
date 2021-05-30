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
    public class RecepcionerServis : IRecepcioner
    {
        public RecepcionerServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    DbSet<Recepcioner> dbSet = db.Set<Recepcioner>();
                    Recepcioner entityToDelete = db.Set<Recepcioner>().Find(id);
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

        public virtual Recepcioner FindById(object id)
        {

            using (var db = new Model1Container1())
            {
                return db.Set<Recepcioner>().Find(id);
            }
        }

        public virtual List<Recepcioner> GetAll()
        {
            using (var db = new Model1Container1())
            {
                return db.Set<Recepcioner>().ToList();
            }
        }

        public bool Insert(Recepcioner entity)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    db.Set<Recepcioner>().Add(entity);
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

        public bool Update(Recepcioner entityToUpdate)
        {
            using (var db = new Model1Container1())
            {
                try
                {
                    db.Set<Recepcioner>().Attach(entityToUpdate);
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
