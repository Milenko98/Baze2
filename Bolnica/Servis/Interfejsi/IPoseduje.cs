using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IPoseduje
    {
        Poseduje FindById(object id);
        List<Poseduje> GetAll();
        bool DeleteZdravstveniKarton(int id);
        bool Insert(Poseduje poseduje);
        bool Delete(object id1, object id2);
        bool DeleteTerapija(int id);
        bool Update(Poseduje poseduje);
    }
}
