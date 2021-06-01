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
    public class RadnikServis : IRadnik
    {
        public RadnikServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Radnik> dbSet = db.Set<Radnik>();
                    Radnik entityToDelete = db.Set<Radnik>().Find(id);
                    db.Entry(entityToDelete).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Message:\n" + e.Message);
                    return false;
                }

            }
        }

        public virtual Radnik FindById(object id)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Radnik>().Find(id);
            }
        }

        public virtual List<Radnik> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Radnik>().ToList();
            }
        }

        public bool Insert(Radnik entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Radnik>().Add(entity);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Message:\n" + e.Message);
                    return false;
                }

            }
        }

        public bool Update(Radnik entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Radnik>().Attach(entityToUpdate);
                    db.Entry(entityToUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Message:\n" + e.Message);
                    return false;
                }

            }
        }
    }
}
