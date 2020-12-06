
namespace Server.Service.Storage {
    static class ConnectionUtil {
        private static string pathNourhane = "C:\\Users\\Lenovo\\OneDrive\\Desktop\\AUB-Time-Management-App\\AUBTimeManagementApp\\Server\\Service\\Storage";
        private static string pathCharbel = "C:\\Users\\PC\\source\\repos\\AUB-Time-Management-App\\AUBTimeManagementApp\\Server\\Service\\Storage";
        private static string pathFarida = "C:\\Users\\User\\source\\repos\\New folder\\AUBTimeManagementApp\\Server\\Service\\Storage";
        private static string pathJihad = "C:\\Users\\user\\Downloads\\AUBTimeManagementApp\\AUBTimeManagementApp\\Server\\Service\\Storage";

        private static string path = pathFarida;
        public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "\\AccountsDataBase.mdf;Integrated Security=True";
    }
}
