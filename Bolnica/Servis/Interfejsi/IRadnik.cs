using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IRadnik
    {
        Radnik FindById(object id);
        List<Radnik> GetAll();
        bool Insert(Radnik radnik);
        bool Delete(object id);
        bool Update(Radnik radnik);
    }
}
