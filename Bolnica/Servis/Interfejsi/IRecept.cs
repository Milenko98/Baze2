using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
     public interface IRecept
    {
        Recept FindById(object id);
        List<Recept> GetAll();
        bool Insert(Recept recept);
        bool Delete(object id);
        bool Update(Recept recept);
    }
}
