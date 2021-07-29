using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using Npgsql;
using Services;

namespace FactoryDB
{
    public class FactoryConnection
    {
        public enum eMotor
        {
            SqlServer = 1,
            Oracle = 2,
            Postgres = 3,
            Soip = 4,
            MySql = 5
        }

        public IDbConnection ObtenerMotor(eMotor param)
        {
            string connectionString = string.Empty;

            switch (param)
            {
                case eMotor.SqlServer:
                    string host = "";
                    string db = "";
                    string user = "";
                    string pass = "";
                    connectionString = @"Data Source = " + host + ";Initial Catalog = " + db + "; User ID = " + user + "; Password = " + pass + "";
                    var con1 = new SqlConnection(connectionString);
                    con1.Open();
                    return con1;
                case eMotor.MySql:
                    host = @"172.17.89.11";
                    db = "reportesudm";
                    user = "admin";
                    pass = "12345678";
                    connectionString = "Server=" + host + ";Database=" + db + ";User ID=" + user + ";Password=" + pass + ";";
                    var con2 = new MySqlConnection(connectionString);
                    con2.Open();
                    return con2;
                case eMotor.Oracle:
                    host = @"";
                    db = "";
                    user = "";
                    pass = "";
                    int portOracle = 0;
                    connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + host + ")(PORT=" + portOracle + ")))(CONNECT_DATA=(SERVICE_NAME=" + db + ")));User ID=" + user + ";Password=" + pass + ";";
                    var con3 = new OracleConnection(connectionString);
                    con3.Open();
                    return con3;
                case eMotor.Postgres:
                    host = @"172.17.89.10";
                    db = "sistemas_ugi";
                    user = "postgres";
                    pass = "post1234";
                    connectionString = "Server=" + host + ";Database=" + db + ";User ID=" + user + ";Password=" + pass + ";";
                    var con4 = new NpgsqlConnection(connectionString);
                    con4.Open();
                    return con4;
                default:
                    return null;
            }
        }
    }
}
