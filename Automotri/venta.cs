using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace Automotri
{
    class venta
    {
        public void AceptarVenta(int ID, string fecha, string descripcion, int empleado, int cliente, int auto)
        {
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Venta_AC";
            cmd.Parameters.AddWithValue("ID", ID);
            cmd.Parameters.AddWithValue("fecha", fecha);
            cmd.Parameters.AddWithValue("_descripcion", descripcion);
            cmd.Parameters.AddWithValue("empleado", empleado);
            cmd.Parameters.AddWithValue("cliente", cliente);
            cmd.Parameters.AddWithValue("auto", auto);
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

        public DataTable get_ven()
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "get_ventas";
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

        public DataTable obtener_V(int id_venta)
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "get_ventas2";
            cmd.Parameters.AddWithValue("id", id_venta);
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

        public void cancelacion(int i)
        {
            ConexionBD2 con = new ConexionBD2();
            MySqlConnection conexion = con.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "EliminarVenta";
            cmd.Parameters.AddWithValue("ID", i);
            conexion.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
