using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IRecepcioner
    {
        Recepcioner FindById(object id);
        List<Recepcioner> GetAll();
        bool Insert(Recepcioner recepcioner);
        bool Delete(object id);
        bool Update(Recepcioner recepcioner);
    }
}
