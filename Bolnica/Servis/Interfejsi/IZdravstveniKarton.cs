using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Interfejsi
{
    public interface IZdravstveniKarton
    {
        ZdravstveniKarton FindById(object id);
        List<ZdravstveniKarton> GetAll();
        bool DeletePacijent(int id);
        bool Insert(ZdravstveniKarton zk);
        bool Delete(object id);
        bool Update(ZdravstveniKarton zk);
    }
}
