using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IPregled
    {
        Pregled FindById(object id);
        List<Pregled> GetAll();
        int FindByName(string name);
        bool Insert(Pregled pregled);
        bool Delete(object id);
        bool Update(Pregled pregled);
    }
}
