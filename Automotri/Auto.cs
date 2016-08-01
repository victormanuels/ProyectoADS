using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Automotri
{
    class Auto
    {


        public DataTable GetCategorias()
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCategoriaAuto";

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




        public DataTable add_Auto(int CaballosFuerza, String direccion, String Transmision, int idModelo, int idCategoria, float costo, Boolean venta, int NumeroMotor)
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "add_Auto";
            cmd.Parameters.AddWithValue("_CaballosFuerza", CaballosFuerza);
            cmd.Parameters.AddWithValue("_direccion", direccion);
            cmd.Parameters.AddWithValue("_Transmision", Transmision);
            cmd.Parameters.AddWithValue("_idModelo", idModelo);
            cmd.Parameters.AddWithValue("_idCategoria", idCategoria);
            cmd.Parameters.AddWithValue("_costo", costo);
            cmd.Parameters.AddWithValue("_venta", venta);
            cmd.Parameters.AddWithValue("_NumeroMotor", NumeroMotor);
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

        public DataTable get_Auto(int idAuto)
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "get_Auto";
            cmd.Parameters.AddWithValue("_idAuto", idAuto);
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

        public DataTable get_AllAuto()
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "get_AllAuto";
            //cmd.Parameters.AddWithValue("_idAuto", idAuto);
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

        public DataTable eliminar_Auto(int idAuto)
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_Auto";
            cmd.Parameters.AddWithValue("_idAuto", idAuto);
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
