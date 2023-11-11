using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI_IVR.Clases;

namespace PPAI_IVR.Datos
{
    public class AccesoBD
    {

        // ver si es mejor obtener una sóla con un id o todas ??
        public static DataTable ObtenerLlamadas()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"SELECT idLlamada, descripcionOperador, duracion, idAccion, opcionSeleccionada, subopcionSeleccionada, nombreCompleto, dniCliente, nroCategoria 
                FROM Llamadas JOIN Clientes C ON (C.dni=Llamadas.dniCliente) JOIN Opciones O ON (Llamadas.opcionSeleccionada=O.nroOrdenOpcion) 
                JOIN Subopciones S ON (Llamadas.subopcionSeleccionada=S.nroOrdenSubopcion)";
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                return tabla;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }

            finally
            {
                cn.Close();
            }

        }

        // Método para obtener todas las informaciones de un cliente.
        public static DataTable ObtenerInformaciones(int dniCliente)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"SELECT datoAValidar FROM Llamadas JOIN Clientes C ON (C.dni=Llamadas.dniCliente) JOIN
                Informaciones I ON (I.dniCliente=C.dni) WHERE (Llamadas.dniCliente=@dni)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dni", dniCliente);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                return tabla;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }

            finally
            {
                cn.Close();
            }

        }


        //Método para obtener los cambios de estado de una llamada
        public static DataTable ObtenerCambiosEstados(int idLlamada)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"SELECT fechaHoraInicia, nombre FROM Llamadas JOIN CambiosEstado CE ON (Llamadas.idLlamada=CE.idLlamada)
                JOIN Estados E ON (CE.idEstado=E.idEstado) WHERE (CE.idLlamada=@id)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idLlamada);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                return tabla;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }

            finally
            {
                cn.Close();
            }

        }

        //Método para obtener las validaciones de una subopcion seleccionada

        public static DataTable ObtenerValidaciones(int subopcionSeleccionada)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"SELECT  nombre, nombreSubopcion from Subopciones S JOIN Validaciones V ON (S.nroOrdenSubopcion=V.nroSubopcion)
                WHERE (S.nroOrdenSubopcion=@subopcion)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@subopcion", subopcionSeleccionada);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                return tabla;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }

            finally
            {
                cn.Close();
            }

        }

        //Método para obtener las subopciones de una opcion seleccionada
        public static DataTable ObtenerSubopciones(int opcionSeleccionada)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"SELECT nombreOpcion, nombreSubopcion, nroOrdenSubopcion from Subopciones S JOIN Opciones O ON (S.nroOpcion=O.nroOrdenOpcion)
                WHERE (O.nroOrdenOpcion=@opcion)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@opcion", opcionSeleccionada);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                return tabla;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }

            finally
            {
                cn.Close();
            }

        }
        // Método para obtener las opciones de una categoria específica
        public static DataTable ObtenerOpciones(int nroCategoria)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"SELECT nombreCategoria, nombreOpcion, nroOrdenOpcion from Opciones O JOIN Categorias C ON (C.nroOrdenCategoria=O.nroCategoria)
                WHERE (C.nroOrdenCategoria=@nroCat)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nroCat", nroCategoria);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                return tabla;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }

            finally
            {
                cn.Close();
            }

        }


        // Método para obtener todas las acciones posibles
        public static DataTable ObtenerAcciones()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"SELECT descripcion FROM Acciones";
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                return tabla;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }

            finally
            {
                cn.Close();
            }

        }

        public static void ActualizarLlamada(Llamada llamada)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"UPDATE Llamadas SET descripcionOperador = @descripcion, duracion = @duracion WHERE (idLlamada=@id)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@descripcion", llamada.DescripcionOperador);
                cmd.Parameters.AddWithValue("@duracion", llamada.Duracion);
                cmd.Parameters.AddWithValue("@id", llamada.IdLlamada);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }

            finally
            {
                cn.Close();
            }

        }

        public static void AgregarCambiosEstado(CambioEstado cambioEstado, int idLlamada)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"INSERT INTO CambiosEstado (idLlamada,fechaHoraInicia, idEstado) VALUES (@idLlamada, @fechaHora, @estado)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idLlamada", idLlamada);
                cmd.Parameters.AddWithValue("@fechaHora", cambioEstado.FechaHoraInicio);
                cmd.Parameters.AddWithValue("@estado", cambioEstado.Estado.Id);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }

            finally
            {
                cn.Close();
            }

        }


    }
}
