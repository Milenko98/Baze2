using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface ILek
    {
        Lek FindById(object id);
        List<Lek> GetAll();
        int FindByName(string name);
        bool Insert(Lek lek);
        bool Delete(object id);
        bool Update(Lek lek);
    }
}
