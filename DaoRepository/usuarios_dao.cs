using System;
using System.Data;
using System.Collections.Generic;
using Services;
using FactoryDB;
using Dapper;

namespace DaoRepository
{
    public class usuarios_dao
    {
        FactoryConnection F = new FactoryConnection();

        public IEnumerable<usuarios_dto> Obtener()
        {
            using (IDbConnection conn = F.ObtenerMotor(FactoryConnection.eMotor.SqlServer))
            {
                string query;
                //para produccion
                #region "Query"
                query = "SELECT * from usuarios";
                #endregion

                try
                {
                    var result = conn.Query<usuarios_dto>(query);
                    return result;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public IEnumerable<usuarios_dto> Obtener(string rut)
        {
            using (IDbConnection conn = F.ObtenerMotor(FactoryConnection.eMotor.SqlServer))
            {
                string query;
                //para produccion
                #region "Query"
                query = "SELECT * from usuarios where rut = @rut";
                #endregion

                try
                {
                    var result = conn.Query<usuarios_dto>(query, new { rut });
                    return result;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public IEnumerable<usuarios_dto> Obtener(string rut, string password)
        {
            using (IDbConnection conn = F.ObtenerMotor(FactoryConnection.eMotor.SqlServer))
            {
                string query;
                //para produccion
                #region "Query"
                query = "SELECT * from usuarios where rut = @rut and password = @password";
                #endregion

                try
                {
                    var result = conn.Query<usuarios_dto>(query, new { rut, password });
                    return result;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        public bool Exist(string rut)
        {
            using (IDbConnection conn = F.ObtenerMotor(FactoryConnection.eMotor.SqlServer))
            {
                string query = "SELECT rut from usuarios where rut = @rut";
                var result = conn.Query(query, new { rut });
                foreach (var dato in result)
                {
                    return true;
                }
                return false;
            }
        }


        public bool Guardar(usuarios_dto dto)
        {
            using (IDbConnection conn = F.ObtenerMotor(FactoryConnection.eMotor.SqlServer))
            {
                int result = 0;
                string query = string.Empty;
                if (!Exist(dto.rut))
                {
                    query = "insert into usuarios (rut, nombre_completo, password) values(@rut, @nombre_completo, @password) ";
                }
                else
                {
                    query = "UPDATE usuarios set nombre_completo = @nombre_completo, password = @password where rut = @rut";
                }

                try
                {
                    result = conn.Execute(query, dto);
                }
                catch (Exception ex)
                {
                    return false;
                }
                return (result > 0) ? true : false;
            }
        }

        public bool Actualizar(usuarios_dto dto)
        {
            using (IDbConnection conn = F.ObtenerMotor(FactoryConnection.eMotor.SqlServer))
            {
                int result = 0;
                string query = string.Empty;
                query = "UPDATE usuarios set nombre_completo = @nombre_completo, password = @password where rut = @rut";
                try
                {
                    result = conn.Execute(query, dto);
                }
                catch (Exception ex)
                {
                    return false;
                }
                return (result > 0) ? true : false;
            }
        }
    }

    public class usuarios_dto
    {
        public string rut { get; set; }
        public string password { get; set; }
        public string nombre_completo { get; set; }
    }
}
