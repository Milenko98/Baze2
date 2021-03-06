using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IPregleda
    {
        Pregleda FindById(object id);
        List<Pregleda> GetAll();
        bool DeletePregled(int id);
        bool DeleteLekar(int id);
        bool Insert(Pregleda pregleda);
        bool Delete(object id1, object id2);
        bool Update(Pregleda pregleda);
    }
}
