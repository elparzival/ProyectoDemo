using System;

namespace Services
{
    public class ParametrosConn
    {
        public static string _sqlserver { get; set; }
        public static string _mysql { get; set; }
        public static string _postgres { get; set; }
        public static string _oracle { get; set; }
        public static string _mock { get; set; }

        public string sqlserver { get; set; }
        public string mysql { get; set; }
        public string postgres { get; set; }
        public string oracle { get; set; }
        public string mock { get; set; }
    }
}
