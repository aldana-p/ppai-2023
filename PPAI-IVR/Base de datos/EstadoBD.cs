using PPAI_IVR.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace PPAI_IVR.Base_de_datos
{
    public class EstadoBD
    {
        public static List<Estado> obtenerEstados()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            List<Estado> lista = new List<Estado>();
            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = @"SELECT * FROM Estado";
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;



                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                sqlDataAdapter.Fill(dataset, "Estado");
                cn.Close();
                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    Estado estado = new Estado(row["nombre"].ToString());
                    lista.Add(estado);
                }
                return lista;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + " " + ex);
                throw;
            }

            finally
            {
                cn.Close();
            }

        }
    }
}
