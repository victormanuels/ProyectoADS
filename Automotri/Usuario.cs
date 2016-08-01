using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace Automotri
{
    class Usuario
    {
        public DataTable get_US()
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "get_usuario";
            dataAdapter.SelectCommand = cmd;
            try
            {
                conexion.Open();
                dataAdapter.Fill(datos);
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            finally
            {
                conexion.Close();
                cmd.Dispose();
                dataAdapter.Dispose();
            }
            return datos;
        }

        public DataTable obtener_us(int id_usuario)
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "get_usuario2";
            cmd.Parameters.AddWithValue("id", id_usuario);
            dataAdapter.SelectCommand = cmd;
            try
            {
                conexion.Open();
                dataAdapter.Fill(datos);
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            finally
            {
                conexion.Close();
                cmd.Dispose();
                dataAdapter.Dispose();
            }
            return datos;
        }

        public bool Chc_Usuario(string usuario, string contra)
        {
            bool chc = false;
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            conexion.Open();
            string sql = "select usuario, pass from usuario where usuario=@usuario";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string u1 = Convert.ToString(reader["usuario"]);
                string c1 = Convert.ToString(reader["pass"]);
                if (u1 == usuario && c1 == contra)
                {
                    chc = true;
                }
                else
                {
                    chc = false;
                }
            }
            return chc;
        }

        public void insertarUsuario(int _ID, string USUARIO, string CONTRA, string NOMBRE,
            string PATERNO, string MATERNO, string FECHA, string CALLE, string COLONIA, string NUMERO,
            string COD, int genero, int puesto)
        {

            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usuarios_AC";
            cmd.Parameters.AddWithValue("_USUARIO", USUARIO);
            cmd.Parameters.AddWithValue("_password", CONTRA);
            cmd.Parameters.AddWithValue("ID", _ID);
            cmd.Parameters.AddWithValue("nombre", NOMBRE);
            cmd.Parameters.AddWithValue("Paterno", PATERNO);
            cmd.Parameters.AddWithValue("materno", MATERNO);
            cmd.Parameters.AddWithValue("nacimiento", FECHA);
            cmd.Parameters.AddWithValue("_calle", CALLE);
            cmd.Parameters.AddWithValue("_colonia", COLONIA);
            cmd.Parameters.AddWithValue("_numero", NUMERO);
            cmd.Parameters.AddWithValue("COD", COD);
            cmd.Parameters.AddWithValue("genero", genero);
            cmd.Parameters.AddWithValue("puesto", puesto);
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            conexion.Close();
        }

        public void eliminarUsuario(int i)
        {
            ConexionBD2 con = new ConexionBD2();
            MySqlConnection conexion = con.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "eliminarUsuario";
            cmd.Parameters.AddWithValue("id", i);
            conexion.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
