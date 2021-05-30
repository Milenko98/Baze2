using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface ITerapija
    {
        Terapija FindById(object id);
        List<Terapija> GetAll();
        bool Insert(Terapija terapija);
        bool Delete(object id);
        bool Update(Terapija terapija);
    }
}
