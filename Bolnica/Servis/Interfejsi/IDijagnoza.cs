using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IDijagnoza
    {
        Dijagnoza FindById(object id);
        List<Dijagnoza> GetAll();
        int FindByName(string name);
        bool Insert(Dijagnoza dijagnoza);
        bool Delete(object id);
        bool Update(Dijagnoza dijagnoza);
    }
}
