using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Storage {
    static class ConnectionUtil {
        private static string path0 = "C:\\Users\\Lenovo\\OneDrive\\Desktop\\AUB-Time-Management-App\\AUBTimeManagementApp\\Server\\Service\\Storage";
        private static string path1 = "C:\\Users\\PC\\source\\repos\\AUB-Time-Management-App\\AUBTimeManagementApp\\Server\\Service\\Storage";
        private static string path2 = "C:\\Users\\User\\source\\repos\\AUB-Time-Management-App\\AUBTimeManagementApp\\Server\\Service\\Storage";

        private static string path = path0;
        public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "\\AccountsDataBase.mdf;Integrated Security=True";
        public static string connectionStringUniversalEventsDB = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "\\EventsUniversalDataBase.mdf;Integrated Security=True";
        public static string connectionStringInvitationsDB = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "\\InvitationsDataBase.mdf;Integrated Security=True";

    }
}
