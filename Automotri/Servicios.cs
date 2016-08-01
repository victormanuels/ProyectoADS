using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;


namespace Automotri
{
    class Servicios
    {



        

        public DataTable GetServicioEnEspecial(int idservicio)
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "VerServciosEnEspecial";
            cmd.Parameters.AddWithValue("_idServicio", idservicio);

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



        public DataTable GetServicio()
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "VerServcios";
  
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

        public DataTable getServiciosRealizados()
        {
            DataTable datos = new DataTable();
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "VerServiciosRealizados";

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





        public void EliminarServicioRealizado(
            int idServicioRealizado)
        {
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "EliminarServicioRealizado";
            cmd.Parameters.AddWithValue("_idServicioRealizado", idServicioRealizado);


            dataAdapter.SelectCommand = cmd;
            try
            {
                conexion.Open();
                cmd.ExecuteReader();
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

        }





        public void AnadirServicioRealizado(
            int idServicioRealizado,
            int idCategoria,
            int idCliente,
            int idServicio,
            DateTime FechaPedido)
        {
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AltaServicioRealizado";
            cmd.Parameters.AddWithValue("_idServicioRealizado", idServicioRealizado);
            cmd.Parameters.AddWithValue("_idCategoria", idCategoria);
            cmd.Parameters.AddWithValue("_idCliente", idCliente);
            cmd.Parameters.AddWithValue("_idServicio", idServicio);
            cmd.Parameters.AddWithValue("_FechaPedido", FechaPedido);

            dataAdapter.SelectCommand = cmd;
            try
            {
                conexion.Open();
                cmd.ExecuteReader();
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

        }

        public void AnadirServicio(int idservicio,
                                   string nombre,
                                   string costo,
                                   string descripcion
                            )
        {
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AltaServicio";
            cmd.Parameters.AddWithValue("_idServicio", idservicio);
            cmd.Parameters.AddWithValue("_NombreServicio", nombre);
            cmd.Parameters.AddWithValue("_costo", costo);
            cmd.Parameters.AddWithValue("_descripcion", descripcion);


            dataAdapter.SelectCommand = cmd;
            try
            {
                conexion.Open();
                cmd.ExecuteReader();
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

        }






        public void DelServicio(int idservicio
                            )
        {
            ConexionBD2 acceso = new ConexionBD2();
            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "EliminarServicio";
            cmd.Parameters.AddWithValue("_idServicio", idservicio);


            dataAdapter.SelectCommand = cmd;
            try
            {
                conexion.Open();
                cmd.ExecuteReader();
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

        }




    }
}
