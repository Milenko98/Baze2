using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface ILekar
    {
        Lekar FindById(object id);
        List<Lekar> GetAll();
        Lekar FindByName(string name);
        bool Insert(Lekar lekar);
        bool Delete(object id);
        bool Update(Lekar lekar);
    }
}
