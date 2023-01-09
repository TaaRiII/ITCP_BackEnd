namespace ITCPBackend.Helper
{
    public class Constants
    {
        public class Status
        {
            public static int Active = 1;
            public static int InActive = 0;
        }
        public class message
        {
            public static string AddMessage = "Successfully Added.";
            public static string UpdateMessage = "Successfully Updated";
        }
        public class UserRoleString
        {
            public static string System = "System";
            public static string Secretariat = "Secretariat";
            public static string Committee = "Committee";
            public static string Management = "Management";
        }
        public class UserRoleInt
        {
            public static int System = 1;
            public static int Secretariat = 2;
            public static int Committee = 3;
            public static int Management = 4;
        }
        public class ClientRoleString
        {
            public static string Entry = "Entry";
            public static string MasterMDA = "MasterMDA";
        }
        public class ClientRoleInt
        {
            public static int MasterMDA = 2;
            public static int Entry = 1;
        }
    }

}
