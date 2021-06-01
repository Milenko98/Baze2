using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IDolazi
    {
        Dolazi FindById(object id);
        List<Dolazi> GetAll();
        bool DeletePregled(int id);
        bool DeletePacijent(int id);
        bool Insert(Dolazi dolazi);
        bool Delete(object id1, object id2);
        bool Update(Dolazi dolazi);
    }
}
