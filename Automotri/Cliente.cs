using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Automotri
{
    class Cliente
    {


        public DataTable GetClientes()
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetClientes";

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


        public DataTable add_Cliente(String nombreCliente, String apellidoPaternoCliente, String apellidoMaternoCliente, DateTime FechaNacimientoCliente, String calle, String numero, String colonia, String codigoPostal, int idGenero)
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "add_Cliente";
            cmd.Parameters.AddWithValue("_nombreCliente", nombreCliente);
            cmd.Parameters.AddWithValue("_apellidoPaternoCliente", apellidoPaternoCliente);
            cmd.Parameters.AddWithValue("_apellidoMaternoCliente", apellidoMaternoCliente);
            cmd.Parameters.AddWithValue("_FechaNacimientoCliente", FechaNacimientoCliente);
            cmd.Parameters.AddWithValue("_calle", calle);
            cmd.Parameters.AddWithValue("_numero", numero);
            cmd.Parameters.AddWithValue("_colonia", colonia);
            cmd.Parameters.AddWithValue("_codigoPostal", codigoPostal);
            cmd.Parameters.AddWithValue("_idGenero", idGenero);
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

        public DataTable get_Cliente(int idCliente)
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "get_Cliente";
            cmd.Parameters.AddWithValue("_idCliente", idCliente);
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
        public DataTable get_AllCliente()
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "get_AllCliente";
            //cmd.Parameters.AddWithValue("_idCliente", idCliente);
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
        public DataTable eliminar_cliente(int idCliente)
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_cliente";
            cmd.Parameters.AddWithValue("_idCliente", idCliente);
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

    }
}
