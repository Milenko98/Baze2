using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IMesto
    {
        Mesto FindById(object id);
        bool Validate(string name);
        List<Mesto> GetAll();
        bool Insert(Mesto mesto);
        bool Delete(object id);
        bool Update(Mesto mesto);
    }
}
