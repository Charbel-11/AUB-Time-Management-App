using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Storage {
    static class ConnectionUtil {
        public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Lenovo\\OneDrive\\Desktop\\AUB-Time-Management-App\\AUBTimeManagementApp\\Server\\Service\\Storage\\AccountsDataBase.mdf;Integrated Security=True";
        public static string connectionStringUniversalEventsDB = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Lenovo\\OneDrive\\Desktop\\AUB-Time-Management-App\\AUBTimeManagementApp\\Server\\Service\\Storage\\EventsUniversalDataBase.mdf;Integrated Security=True";

    }
}
