using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IIzdaje
    {
        Izdaje FindById(object id);
        List<Izdaje> GetAll();
        bool Insert(Izdaje izdaje);
        bool Delete(object id1, object id2, object id3);
        bool Update(Izdaje izdaje);
    }
}
