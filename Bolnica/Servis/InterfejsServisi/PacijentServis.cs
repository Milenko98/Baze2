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
    public class PacijentServis : IPacijent
    {
        public PacijentServis() { }
        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Pacijent> dbSet = db.Set<Pacijent>();
                    Pacijent entityToDelete = db.Set<Pacijent>().Find(id);
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

        public virtual Pacijent FindById(object id)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Pacijent>().Find(id);
            }
        }

        public virtual List<Pacijent> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Pacijent>().ToList();
            }
        }

        public bool Insert(Pacijent entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Pacijent>().Add(entity);
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

        public bool Update(Pacijent entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Pacijent>().Attach(entityToUpdate);
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
        public Pacijent FindByName(string name)
        {
            using (var db = new Model1Container())
            {
                var pom = db.Set<Pacijent>().First(f => f.Ime == name);
                return pom;
            }
        }
    }
}
