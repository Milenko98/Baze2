using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface ISeLeci
    {
        SeLeci FindById(object id);
        List<SeLeci> GetAll();
        bool Insert(SeLeci seLeci);
        bool DeleteLek(int id);
        bool DeleteDijagnoza(int id);
        bool Delete(object id1, object id2);
        bool Update(SeLeci seLeci);
    }
}
