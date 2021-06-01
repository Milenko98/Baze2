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
    public class MestoServis : IMesto
    {

        public MestoServis()
        {

        }

        public virtual bool Delete(object id)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    DbSet<Mesto> dbSet = db.Set<Mesto>();
                    Mesto entityToDelete = db.Set<Mesto>().Find(id);
                    db.Set<Mesto>().Remove(entityToDelete);
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

        public virtual Mesto FindById(object id)
        {

            using (var db = new Model1Container())
            {
                return db.Set<Mesto>().Find(id);
            }
        }

        public virtual List<Mesto> GetAll()
        {
            using (var db = new Model1Container())
            {
                return db.Set<Mesto>().ToList();
            }
        }

        public bool Insert(Mesto entity)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Mesto>().Add(entity);
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

        public bool Update(Mesto entityToUpdate)
        {
            using (var db = new Model1Container())
            {
                try
                {
                    db.Set<Mesto>().Attach(entityToUpdate);
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

        public int FindByName(string name)
        {
            using (var db = new Model1Container())
            {
                var pom = db.Set<Mesto>().First(f => f.Naziv == name);
                return pom.P_Broj;
            }
        }

        public bool Validate(string name)
        {
            using (var db = new Model1Container())
            {
                if (db.Set<Mesto>().FirstOrDefault(f => f.Naziv == name) != null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
