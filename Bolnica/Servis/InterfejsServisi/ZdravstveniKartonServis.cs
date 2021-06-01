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
                    Console.WriteLine("Message:\n" + e.Message);
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
                    Console.WriteLine("Message:\n" + e.Message);
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
                    Console.WriteLine("Message:\n" + e.Message);
                    return false;
                }

            }
        }

        public bool DeletePacijent(int id)
        {
            List<ZdravstveniKarton> lista = new List<ZdravstveniKarton>();
            SadrziServis ss = new SadrziServis();
            PosedujeServis ps = new PosedujeServis();
            bool b1 = false, b2 = false;
            using (var db = new Model1Container())
            {
                try
                {
                    lista = db.Set<ZdravstveniKarton>().ToList();
                    if (lista.Count != 0)
                    {
                        foreach (var v in lista)
                        {
                            if (v.PacijentJmbg == id)
                            {
                                if (ss.DeleteZdravstveniKarton(v.Broj_K))
                                    b1 = true;
                                if (ps.DeleteZdravstveniKarton(v.Broj_K))
                                    b2 = true;
                                if (b1 || b2)
                                    db.Set<ZdravstveniKarton>().Remove(v);
                                else
                                    db.Set<ZdravstveniKarton>().Remove(v);
                            }
                        }
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
