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
    public partial class GestionAutos : Form
    {
        public GestionAutos()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                AltaAutos Frm3 = new AltaAutos();
                Frm3.idAuto = Convert.ToInt32(lv.SelectedItems[0].Tag);
                Frm3.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Un campo debe ser selecciónado!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaAutos frm = new AltaAutos();
            frm.Show();
        }

        private void GestionAutos_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            
            Auto auto = new Auto();
            DataTable Autos = new DataTable();
            try
            {
                lv.Clear();
                lv.Columns.Add("Caballos de Fuerza", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Dirección", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Transmision", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Modelo", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Categoria", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Costo", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Disponibilidad", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Número de Motor", 100, HorizontalAlignment.Left);
                Autos = auto.get_AllAuto();
                for (int i = 0; i < Autos.Rows.Count; i++)
                {
                    DataRow dr = Autos.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["CaballosFuerza"].ToString());
                    listitem.Tag = dr["idAuto"].ToString();
                    listitem.SubItems.Add(dr["direccion"].ToString());
                    listitem.SubItems.Add(dr["Transmision"].ToString());
                    listitem.SubItems.Add(dr["idModelo"].ToString());
                    if (dr["idCategoria"].ToString() == "1")
                    {
                        listitem.SubItems.Add("Compacto");
                    }
                    if (dr["idCategoria"].ToString() == "2")
                    {
                        listitem.SubItems.Add("Lujo");
                    }
                    if (dr["idCategoria"].ToString() == "3")
                    {
                        listitem.SubItems.Add("Premium");
                    }
                    if (dr["idCategoria"].ToString() == "4")
                    {
                        listitem.SubItems.Add("Convertible");
                    }
                    listitem.SubItems.Add(dr["Costo"].ToString());
                    if (dr["venta"].ToString() == "True")
                    {
                        listitem.SubItems.Add("No Disponible");
                    }
                    else
                    {
                        listitem.SubItems.Add("Disponible");
                    }
                    listitem.SubItems.Add(dr["NumeroMotor"].ToString());
                    lv.Items.Add(listitem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
           
            Auto auto = new Auto();
          

            try
            {
                int a = Convert.ToInt32(lv.SelectedItems[0].Tag);
                DialogResult dr = MessageBox.Show("¿Esta seguro que quiere eliminar dicho automovil?", "Eliminar Auto", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    auto.eliminar_Auto(a);
                    MessageBox.Show("Se ha eliminado!");
                }
                else if (dr == DialogResult.No)
                {
                    MessageBox.Show("No se ha hecho nada.");
                }
            }
            catch
            {
                MessageBox.Show("Un campo debe ser selecciónado!");
            }

        }
    }
}