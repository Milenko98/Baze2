using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IObezbedjenje
    {
        Obezbedjenje FindById(object id);
        List<Obezbedjenje> GetAll();
        bool Insert(Obezbedjenje obezbedjenje);
        bool Delete(object id);
        bool Update(Obezbedjenje obezbedjenje);
    }
}
