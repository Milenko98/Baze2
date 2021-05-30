using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IOsoba
    {
        Osoba FindById(object id);
        int FindByName(string name);
        List<Osoba> GetAll();
        bool Insert(Osoba osoba);
        bool Delete(object id);
        bool Update(Osoba osoba);
    }
}
