using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automotri
{
    public partial class AltaUsuario : Form
    {
        public int ID_US = 0;
        public AltaUsuario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int genero, puesto;
            Usuario alUS = new Usuario();
            if (textBox9.Text == "" || textBox7.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" ||
                textBox8.Text == "" || textBox6.Text == "" || textBox5.Text == "" || textBox3.Text == "" || comboBox2.Text == "Seleccione:" || comboBox1.Text == "Seleccione:")
            {
                MessageBox.Show("Llene todos los campos requeridos");
            }
            else
            {
                if (comboBox2.Text == "Masculino")
                {
                    genero = 1;
                }
                else
                {
                    genero = 2;
                }
                if (comboBox1.Text == "Administrador")
                {
                    puesto = 1;
                }
                else
                {
                    if (comboBox1.Text == "Servicios")
                    {
                        puesto = 2;
                    }
                    else
                    {
                        puesto = 3;
                    }
                }
                alUS.insertarUsuario(ID_US, textBox9.Text, textBox7.Text, textBox1.Text, textBox2.Text, textBox4.Text, dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"),
                    textBox8.Text, textBox6.Text, textBox5.Text, textBox3.Text, genero, puesto);
                MessageBox.Show("Exito");

                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            if (ID_US == 0)
            {
                comboBox2.Text = "Seleccione:";
                comboBox1.Text = "Seleccione:";
            }
            else
            {
                string g;
                Usuario alUS = new Usuario();
                DataTable emp = new DataTable();
                emp = alUS.obtener_us(ID_US);
                DataRow dr = emp.Rows[0];
                textBox1.Text = dr["nombreEmpleado"].ToString();
                textBox2.Text = dr["apellidoPaternoEmpleado"].ToString();
                textBox4.Text = dr["apellidoMaternoEmpleado"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr["FechaNacimientoEmpleado"]);
                textBox8.Text = dr["calle"].ToString();
                textBox5.Text = dr["numero"].ToString();
                textBox6.Text = dr["colonia"].ToString();
                textBox3.Text = dr["codigoPostal"].ToString();
                comboBox1.Text = dr["puesto"].ToString();
                textBox9.Text = dr["usuario"].ToString();
                textBox7.Text = dr["pass"].ToString();
                g = dr["idgenero"].ToString();
                if (g == "1")
                {
                    comboBox2.Text = "Masculino";
                }
                else
                {
                    comboBox2.Text = "Femenino";
                }
            }

        }

      
    }
}
