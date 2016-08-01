using System;
using System.Collections.Generic;
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
    public partial class AltaAutos : Form
    {
        public int idAuto;
        public AltaAutos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AltaAutos_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            if (idAuto == 0)
            {
                CaballosDeFuerza.Text = "";
                Direccion.Text = "";
                Transmision.Text = "";
                Modelo.Text = "";
                Costo.Text = "";
                comboBox1.Text = "";
                NumeroDeMotor.Text = "";
            }
            else
            {
                //Consutar datos de la persona en la BD
                Auto autos = new Auto();
                DataTable Autos = autos.get_Auto(idAuto);
                DataRow dr = Autos.Rows[0];
                CaballosDeFuerza.Text = dr["CaballosFuerza"].ToString();
                Direccion.Text = dr["direccion"].ToString();
                Transmision.Text = dr["Transmision"].ToString();
                Modelo.Text = dr["idModelo"].ToString();
                comboBox1.Text = dr["idCategoria"].ToString();
                NumeroDeMotor.Text = dr["NumeroMotor"].ToString();
                if (dr["idCategoria"].ToString() == "1")
                {
                    comboBox1.Text = ("Compacto");
                }
                if (dr["idCategoria"].ToString() == "2")
                {
                    comboBox1.Text = ("Lujo");
                }
                if (dr["idCategoria"].ToString() == "3")
                {
                    comboBox1.Text = ("Premium");
                }
                if (dr["idCategoria"].ToString() == "4")
                {
                    comboBox1.Text = ("Convertible");
                }
                comboBox1.Enabled = false;
                Costo.Text = (dr["Costo"].ToString());
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CaballosDeFuerza.Text == "")
            {
                MessageBox.Show("El campo Caballos de Fuerza es obligatorio");
                return;
            }
            if (Direccion.Text == "")
            {
                MessageBox.Show("El campo Dirección es obligatorio");
                return;
            }
            if (Transmision.Text == "")
            {
                MessageBox.Show("El campo Transmision es obligatorio");
                return;
            }
            if (Modelo.Text == "")
            {
                MessageBox.Show("El campo Modelo es obligatorio");
                return;
            }
            if (Costo.Text == "")
            {
                MessageBox.Show("El campo Costo es obligatorio");
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Se debe seleccionar una categoria");
                return;
            }
            if (NumeroDeMotor.Text == "")
            {
                MessageBox.Show("El campo Numero de Motor es obligatorio");
                return;
            }
            String c = comboBox1.Text;
            int cat = 0;
            if (c == "Compact")
            {
                cat = 1;
            }
            else if (c == "Lujo")
            {
                cat = 2;
            }
            else if (c == "Premium")
            {
                cat = 3;
            }
            else if (c == "Convertible")
            {
                cat = 4;
            }
            Auto auto = new Auto();
            try
            {
                DataTable Autos = auto.add_Auto(Int32.Parse(CaballosDeFuerza.Text), Direccion.Text, Transmision.Text, Int32.Parse(Modelo.Text), cat, Convert.ToSingle(Costo.Text), false, Int32.Parse(NumeroDeMotor.Text));
                MessageBox.Show("Automovil agregado!");
                CaballosDeFuerza.Text = "";
                Direccion.Text = "";
                Transmision.Text = "";
                comboBox1.Text = "";
                Modelo.Text = "";
                Costo.Text = "";
                NumeroDeMotor.Text = "";
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

      
    }
}
