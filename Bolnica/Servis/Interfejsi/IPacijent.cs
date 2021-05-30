using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IPacijent
    {
        Pacijent FindById(object id);
        Pacijent FindByName(string name);
        List<Pacijent> GetAll();
        bool Insert(Pacijent pacijent);
        bool Delete(object id);
        bool Update(Pacijent radnik);
    }
}
