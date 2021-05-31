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
    public class ZdravstveniKartonServis : IZdravstveniKarton
    {
        public ZdravstveniKartonServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<ZdravstveniKarton> dbSet = db.Set<ZdravstveniKarton>();
                    ZdravstveniKarton entityToDelete = db.Set<ZdravstveniKarton>().Find(id);
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

        public virtual ZdravstveniKarton FindById(object id)
        {

            using (var db = new Model1Container())
            {
                return db.Set<ZdravstveniKarton>().Find(id);
            }
        }

        public virtual List<ZdravstveniKarton> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<ZdravstveniKarton>().ToList();
            }
        }

        public bool Insert(ZdravstveniKarton entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<ZdravstveniKarton>().Add(entity);
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

        public bool Update(ZdravstveniKarton entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<ZdravstveniKarton>().Attach(entityToUpdate);
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
