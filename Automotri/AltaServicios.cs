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
    public partial class AltaServicios : Form
    {
        private int idServicio;

        public AltaServicios(int aidservice)
        {
            InitializeComponent();
            idServicio = aidservice;
        }


        private void VaciarCampos()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            richTextBox1.Text = "";

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AltaServicios_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            
            if (idServicio != 0)
            {
                label1.Text = "Editar servicio";
                Servicios se = new Servicios();
                DataTable Server = new DataTable();
                Server = se.GetServicioEnEspecial(idServicio);

                DataRow dr = Server.Rows[0];

                textBox1.Text = dr["NombreServicio"].ToString();
                textBox3.Text = dr["Costo"].ToString();
                richTextBox1.Text = dr["descripcion"].ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void button1_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrEmpty(textBox1.Text) ||
          string.IsNullOrEmpty(textBox3.Text) ||
          string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Todos los campos son necesarios");
            }
            else
            {

                try
                {
                    double x = Convert.ToDouble(textBox3.Text);
                    Servicios ser = new Servicios();
                    ser.AnadirServicio(idServicio, textBox1.Text, textBox3.Text, richTextBox1.Text);
                    VaciarCampos();
                    if (idServicio == 0)
                    {
                        MessageBox.Show("Alta realizada con exito");
                    }
                    else
                    {
                        MessageBox.Show("Edicion realizada con exito");
                    }
                    this.Hide();
                }
                catch (Exception)
                {
                    MessageBox.Show("En el campo costo son necesarios los valores numericos");
                    textBox3.Text = "";

                }


            }

        }


    }
}
