using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface ILecenje
    {
        Lecenje FindById(object id1, object id2);
        List<Lecenje> GetAll();
        bool Insert(Lecenje lecenje);
        bool Delete(object id1, object id2);
    }
}
