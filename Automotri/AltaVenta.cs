using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Automotri
{
    public partial class AltaVenta : Form
    {
        public int ID_ven = 0;
        public AltaVenta()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            venta v1 = new venta();
            int emp, au, cl;
            if (comboBox1.Text == "Selecione:" || comboBox2.Text == "Selecione:" || comboBox3.Text == "Selecione:" || richTextBox1.Text == "")
            {
                MessageBox.Show("Llene todos los campos requeridos");
            }
            else
            {
                emp = Int32.Parse(comboBox3.SelectedValue.ToString());
                cl = Int32.Parse(comboBox2.SelectedValue.ToString());
                au = Int32.Parse(comboBox1.SelectedValue.ToString());
                v1.AceptarVenta(ID_ven, dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"), richTextBox1.Text, emp, cl, au);
                MessageBox.Show("Exito");
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void AltaVenta_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            ConexionBD2 acceso = new ConexionBD2();
            DataTable datos = new DataTable();
            DataTable datos2 = new DataTable();

            DataTable datos3 = new DataTable();

            MySqlConnection conexion = acceso.conexionMySql();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "get_Empleado";
            cmd.Parameters.AddWithValue("id", 3);
            dataAdapter.SelectCommand = cmd;
            try
            {
                conexion.Open();
                dataAdapter.Fill(datos);
                comboBox3.ValueMember = "idEmpleado";
                comboBox3.DisplayMember = "nombrec";
                comboBox3.DataSource = datos;
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            cmd.CommandText = "get_autoMiguel";
            dataAdapter.SelectCommand = cmd;
            try
            {

                dataAdapter.Fill(datos2);
                comboBox1.ValueMember = "IdAuto";
                comboBox1.DisplayMember = "modelo";
                comboBox1.DataSource = datos2;
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            cmd.CommandText = "get_clienteMiguel";
            dataAdapter.SelectCommand = cmd;
            try
            {

                dataAdapter.Fill(datos3);
                comboBox2.ValueMember = "idCliente";
                comboBox2.DisplayMember = "apellidoPaternoCliente";
                comboBox2.DataSource = datos3;
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            if (ID_ven == 0)
            {
                comboBox1.Text = "Selecione:";
                comboBox2.Text = "Selecione:";
                comboBox3.Text = "Selecione:";
            }
            else
            {
                venta ventaEdito = new venta();
                DataTable emp = new DataTable();
                emp = ventaEdito.obtener_V(ID_ven);
                DataRow dr = emp.Rows[0];
                comboBox3.Text = dr["apellidoPaternoEmpleado"].ToString();
                comboBox1.Text = dr["modelo"].ToString();
                comboBox2.Text = dr["apellidoPaternoCliente"].ToString();
                richTextBox1.Text = dr["descripcion"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr["fechaVenta"]);
            }


        }

    }
}
