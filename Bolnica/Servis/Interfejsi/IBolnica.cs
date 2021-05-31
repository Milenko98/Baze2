using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IBolnica
    {
        Bolnica FindById(object id);
        bool Validate(string name);
        int FindByName(string name);
        List<Bolnica> GetAll();
        bool Insert(Bolnica bolnica);
        bool Delete(object id);
        bool Update(Bolnica bolnica);
    }
}
