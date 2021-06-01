using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface ISadrzi
    {
        Sadrzi FindById(object id);
        List<Sadrzi> GetAll();
        bool DeleteZdravstveniKarton(int id);
        bool Insert(Sadrzi sadrzi);
        bool DeleteDijagnoza(int id);
        bool Delete(object id1, object id2);
        bool Update(Sadrzi sadrzi);
    }
}
