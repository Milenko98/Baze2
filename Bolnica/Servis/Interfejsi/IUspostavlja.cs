using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IUspostavlja
    {
        Uspostavlja FindById(object id1, object id2);
        List<Uspostavlja> GetAll();
        bool DeleteLecenje(int id1, int id2);
        bool DeleteDijagnoza(int id);
        bool Insert(Uspostavlja uspostavka);
        bool Delete(object id1, object id2);
    }
}
