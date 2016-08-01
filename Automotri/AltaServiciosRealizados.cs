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
    public partial class AltaServiciosRealizados : Form
    {
        private int idserviciorealizado;
        public AltaServiciosRealizados( int aid)
        {
            InitializeComponent();
            idserviciorealizado = aid;
        }



        private void AltaServiciosRealizados_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            Servicios sur = new Servicios();
            DataTable Serv = new DataTable();
            Serv = sur.GetServicio();

            comboBox3.DataSource = Serv;
            comboBox3.DisplayMember = "NombreServicio";
            comboBox3.ValueMember = "idServicio";


            Cliente client = new Cliente();
            DataTable cli = new DataTable();
            cli = client.GetClientes();

            comboBox1.DataSource = cli;
            comboBox1.DisplayMember = "nombrec";
            comboBox1.ValueMember = "idcliente";


            Auto Categ = new Auto();
            DataTable cat = new DataTable();
            cat = Categ.GetCategorias();

            comboBox2.DataSource = cat;
            comboBox2.DisplayMember = "Categoria";
            comboBox2.ValueMember = "idCategoria";

        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
             }

        private void button2_Click(object sender, EventArgs e)
        {
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(comboBox2.SelectedValue);
            int b = Convert.ToInt32(comboBox1.SelectedValue);
            int c = Convert.ToInt32(comboBox3.SelectedValue);
            DateTime fechapedido = dateTimePicker1.Value;

            // MessageBox.Show(a + "" + b + "" + c + "" + fechapedido);

            Servicios ser = new Servicios();
            ser.AnadirServicioRealizado(idserviciorealizado, a, b, c, fechapedido);
            MessageBox.Show("Servicio realizado con exito");
            this.Hide();
       
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
