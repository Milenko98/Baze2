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
    public class LekServis : ILek
    {

        public LekServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Lek> dbSet = db.Set<Lek>();
                    Lek entityToDelete = db.Set<Lek>().Find(id);
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

        public virtual Lek FindById(object id)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Lek>().Find(id);
            }
        }

        public virtual List<Lek> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Lek>().ToList();
            }
        }

        public bool Insert(Lek entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Lek>().Add(entity);
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

        public bool Update(Lek entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Lek>().Attach(entityToUpdate);
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

        public int FindByName(string name)
        {
            using (var db = new Model1Container())
            {
                var pom = db.Set<Lek>().First(f => f.Naziv == name);
                return pom.Id_Leka;
            }
        }
    }
}
