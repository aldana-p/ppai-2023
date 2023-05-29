using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR.Clases;
using System.Windows.Forms;

namespace PPAI_IVR.Base_de_datos
{
    public class CambioEstadoBD
    {


        // Pruba inserción de llamada

        public static bool InsertarCliente()
        {

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            bool resultado = false;


            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"INSERT INTO Cliente (dni, nombre) VALUES(@dni, @nom)";


                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dni", 123213);
                cmd.Parameters.AddWithValue("nom", "Prieto Aldana");
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + " " + ex);
            }

            finally
            {
                cn.Close();
            }



            return resultado;
        }
        public static bool InsertarSubopcion(string nombre)
        {

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            bool resultado = false;


            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"INSERT INTO Subopcion (nombre) VALUES(@nom)";


                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nom", nombre);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + " " + ex);
            }

            finally
            {
                cn.Close();
            }



            return resultado;
        }


        public static bool InsertarOpcion(string nombre)
        {

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            bool resultado = false;


            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"INSERT INTO Opcion (nombre) VALUES(@nom)";


                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nom", nombre);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + " " + ex);
            }

            finally
            {
                cn.Close();
            }



            return resultado;
        }



        public static bool insertaCambioEstado()
        {

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            bool resultado = false;


            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"INSERT INTO CambioEstado (fechaHoraInicio, estado ) VALUES(@desc, @detalle, @duracion, @cliente, @op, @subop)";


                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@desc", "A completar");
                cmd.Parameters.AddWithValue("@detalle", "A completar");
                cmd.Parameters.AddWithValue("@duracion", 0);
                cmd.Parameters.AddWithValue("@cliente", 1);
                cmd.Parameters.AddWithValue("@op", 1);
                cmd.Parameters.AddWithValue("@subop", 1);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + " " + ex);
            }

            finally
            {
                cn.Close();
            }



            return resultado;
        }

    }

}
