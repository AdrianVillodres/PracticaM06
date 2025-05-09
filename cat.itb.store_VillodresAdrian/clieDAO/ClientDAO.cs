using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cat.itb.store_VillodresAdrian.depDAO;

namespace cat.itb.store_VillodresAdrian.clieDAO
{
    public interface ClientDAO
    {

        void DeleteAll();
        void InsertAll(List<Client> cli);
        List<Client> SelectAll();
        Client Select(int cliId);
        Boolean Insert(Client cli);

        Boolean Delete(int cliId);

        Boolean Update(Client cli);

        List<Client> SelectByEmpId(int CliId);

        List<Client> SelectByEmpSurname(string surname);

    }
}
