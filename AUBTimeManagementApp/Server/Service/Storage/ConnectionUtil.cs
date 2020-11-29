
namespace Server.Service.Storage {
    static class ConnectionUtil {
        private static string path0 = "C:\\Users\\Lenovo\\OneDrive\\Desktop\\AUB-Time-Management-App\\AUBTimeManagementApp\\Server\\Service\\Storage";
        private static string pathCharbel = "C:\\Users\\PC\\source\\repos\\AUB-Time-Management-App\\AUBTimeManagementApp\\Server\\Service\\Storage";
        private static string path2 = "C:\\Users\\User\\source\\repos\\AUB-Time-Management-App\\AUBTimeManagementApp\\Server\\Service\\Storage";
        private static string path3 = "C:\\Users\\User\\source\\repos\\New folder\\AUBTimeManagementApp\\Server\\Service\\Storage";
        private static string pathJihad = "C:\\Users\\user\\Downloads\\AUBTimeManagementApp\\AUBTimeManagementApp\\Server\\Service\\Storage";

        private static string path = pathCharbel;
        public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "\\AccountsDataBase.mdf;Integrated Security=True";
    }
}
