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
            MySql = 4,
            Mock = 5
        }

        public IDbConnection ObtenerMotor(eMotor param)
        {
            string connectionString = string.Empty;

            switch (param)
            {
                case eMotor.SqlServer:
                    connectionString = @ParametrosConn._sqlserver;
                    var con1 = new SqlConnection(connectionString);
                    con1.Open();
                    return con1;
                case eMotor.MySql:
                    connectionString = @ParametrosConn._mysql;
                    var con2 = new MySqlConnection(connectionString);
                    con2.Open();
                    return con2;
                case eMotor.Oracle:
                    connectionString = ParametrosConn._oracle;
                    var con3 = new OracleConnection(connectionString);
                    con3.Open();
                    return con3;
                case eMotor.Postgres:
                    connectionString = ParametrosConn._postgres;
                    var con4 = new NpgsqlConnection(connectionString);
                    con4.Open();
                    return con4;
                case eMotor.Mock:
                    connectionString = ParametrosConn._mock;
                    var con5 = new NpgsqlConnection(connectionString);
                    con5.Open();
                    return con5;
                default:
                    return null;
            }
        }
    }
}
