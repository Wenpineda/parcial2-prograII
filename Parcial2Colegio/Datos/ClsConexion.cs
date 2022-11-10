using Parcial2Colegio.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2Colegio.Datos
{
    public class ClsConexion
    {
        private string connectionString = "Data Source=DESKTOP-GCJF4AE; Initial Catalog=RegistroNotas; Integrated Security=SSPI";

        public bool Ok()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
            }
            catch
            {

                return false;
            }
            return true;

        }

        public List<clsEstudiante> GetEstudiantes()
        {
            List<clsEstudiante> estudiante = new List<clsEstudiante>();

            string query = "select id,nombre, apellido, carrera, asignatura, promedio1, promedio2, promedio3, promediofinal from Estudiantes ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        clsEstudiante oEstudiante = new clsEstudiante();
                        oEstudiante.id = reader.GetInt32(0);
                        oEstudiante.nombre = reader.GetString(1);
                        oEstudiante.apellido = reader.GetString(2);
                        oEstudiante.carrera = reader.GetString(3);
                        oEstudiante.asignatura = reader.GetString(4);
                        oEstudiante.promedio1 = reader.GetDecimal(5);
                        oEstudiante.promedio2 = reader.GetDecimal(6);
                        oEstudiante.promedio3 = reader.GetDecimal(7);
                        oEstudiante.promediofinal = reader.GetDecimal(8);
                        estudiante.Add(oEstudiante);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hay un error en la Base de Datos" + ex.Message);
                }
            }

            return estudiante;
        }



        public void Insertar(string Nombre, string Apellido, string Carrera, string Asginatura, decimal Promedio1, decimal Promedio2, decimal Promedio3, decimal PromedioFinal)
        {
            string query = "Insert into Estudiantes (nombre, apellido, carrera, asignatura, promedio1, promedio2, promedio3, promedioFinal) values" + "(@nombre, @apellido, @carrera, @asignatura, @promedio1, @promedio2, @promedio3, @promediofinal)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@apellido", Apellido);
                command.Parameters.AddWithValue("@carrera", Carrera);
                command.Parameters.AddWithValue("@asignatura", Asginatura);
                command.Parameters.AddWithValue("@promedio1", Promedio1);
                command.Parameters.AddWithValue("@promedio2", Promedio2);
                command.Parameters.AddWithValue("@promedio3", Promedio3);
                command.Parameters.AddWithValue("@promediofinal", PromedioFinal);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();


                }
                catch (Exception e)
                {

                    MessageBox.Show("Error" + e.Message);
                }
            }
        }
    }
}


