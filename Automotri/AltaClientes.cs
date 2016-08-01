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
    public partial class AltaClientes : Form
    {
        public int idCliente;
        public AltaClientes()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AltaClientes_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            
            if (idCliente == 0)
            {
                txtNombre.Text = "";
                txtPaterno.Text = "";
                txtMaterno.Text = "";
                comboBox2.Text = "";
                txtCP.Text = "";
                txtCalle.Text = "";
                txtColonia.Text = "";
                txtColonia.Text = "";
            }
            else
            {
                //Consutar datos de la persona en la BD
                Cliente cliente = new Cliente();
                DataTable datosCliente = cliente.get_Cliente(idCliente);
                DataRow dr = datosCliente.Rows[0];
                txtNombre.Text = dr["nombreCliente"].ToString();
                txtPaterno.Text = dr["apellidoPaternoCliente"].ToString();
                txtMaterno.Text = dr["apellidoMaternoCliente"].ToString();
                txtCalle.Text = dr["calle"].ToString();
                txtColonia.Text = dr["colonia"].ToString();
                txtColonia.Text = dr["numero"].ToString();
                txtColonia.Text = dr["colonia"].ToString();
                dtp.Value = Convert.ToDateTime(dr["FechaNacimientoCliente"]);
                txtCP.Text = dr["codigoPostal"].ToString();
                if (dr["idGenero"].ToString() == "1")
                {
                    comboBox2.Text = ("Masculino");
                }
                else
                {
                    comboBox2.Text = ("Femenino");
                }
                comboBox2.Enabled = false;
            }
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (dtp.Value > DateTime.Now)
            {
                MessageBox.Show("Fecha irronea");
                return;
            }
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El campo Nombre es obligatorio");
                return;
            }
            if (txtPaterno.Text == "")
            {
                MessageBox.Show("El campo Nombre Paterno es obligatorio");
                return;
            }
            if (txtMaterno.Text == "")
            {
                MessageBox.Show("El campo Nombre Materno es obligatorio");
                return;
            }
            if (txtCalle.Text == "")
            {
                MessageBox.Show("El campo Calle es obligatorio");
                return;
            }
            if (txtColonia.Text == "")
            {
                MessageBox.Show("El campo Número es obligatorio");
                return;
            }
            if (txtColonia.Text == "")
            {
                MessageBox.Show("El campo Colonia es obligatorio");
                return;
            }
            if (txtCP.Text == "")
            {
                MessageBox.Show("El campo Código Postal es obligatorio");
                return;
            }
            String s = comboBox2.Text;
            int sexo = 0;
            if (s == "Masculino")
            {
                sexo = 1;
            }
            else if (s == "Femenino")
            {
                sexo = 2;
            }
            Cliente cliente = new Cliente();
            try
            {
                DataTable datosCliente = cliente.add_Cliente(txtNombre.Text, txtPaterno.Text, txtMaterno.Text, Convert.ToDateTime(dtp.Value), txtCalle.Text, txtColonia.Text, txtColonia.Text, txtCP.Text, sexo);
                MessageBox.Show("Cliente agregado!");
                txtNombre.Text = "";
                txtPaterno.Text = "";
                txtMaterno.Text = "";
                comboBox2.Text = "";
                txtCP.Text = "";
                txtCalle.Text = "";
                txtColonia.Text = "";
                txtColonia.Text = "";
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}