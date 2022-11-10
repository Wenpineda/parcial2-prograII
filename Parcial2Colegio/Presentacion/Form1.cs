using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial2Colegio.Datos;

namespace Parcial2Colegio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClsConexion oEstudiante = new ClsConexion();
            if ( oEstudiante.Ok())
            {
                MessageBox.Show("Conexion Exitosa");
                MostrarEstudiantes();
            }
            else
            {
                MessageBox.Show("Error de Conexion");
            }

        }

        private void MostrarEstudiantes()
        {
            ClsConexion oEstudiante = new ClsConexion();
            dataGridView1.DataSource = oEstudiante.GetEstudiantes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsConexion oEstudiante = new ClsConexion();
            try
            {
                calcularPromedio();
                oEstudiante.Insertar(txtnombre.Text, txtapellido.Text, txtcarrera.Text, txtasignatura.Text, Convert.ToDecimal(txtpromedio1.Text), Convert.ToDecimal(txtpromedio2.Text), Convert.ToDecimal(txtpromedio3.Text), Convert.ToDecimal(txtpromediofinal.Text));
                MostrarEstudiantes();
                LimpiarCampos();


            }
            catch (Exception)
            {

                MessageBox.Show("No se admiten campos vacios");
            }
            void calcularPromedio()
            {
                if (txtpromedio1.Text != "" && txtpromedio2.Text != "" && txtpromedio3.Text != "")
                {
                    Decimal PromedioFinal = (Convert.ToDecimal(txtpromedio1.Text)
                        + Convert.ToDecimal(txtpromedio2.Text) + Convert.ToDecimal(txtpromedio3.Text)) / 3;

                    txtpromediofinal.Text = PromedioFinal.ToString("N2");

                }
                else
                {
                    MessageBox.Show("Faltan datos");

                }
            }
            void LimpiarCampos()
            {
                txtnombre.Text = string.Empty;
                txtapellido.Text = string.Empty;
                txtcarrera.Text = string.Empty;
                txtasignatura.Text = string.Empty;
                txtpromedio1.Text = string.Empty;
                txtpromedio2.Text = string.Empty;
                txtpromedio3.Text = string.Empty;
                txtpromediofinal.Text = string.Empty;

            }
        }
    }
}
