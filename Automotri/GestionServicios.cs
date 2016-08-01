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
    public partial class GestionServicios : Form
    {
        public GestionServicios()
        {
            InitializeComponent();
            CrearTabla();
        }


        public void CrearTabla()
        {

            Servicios ss = new Servicios();
            DataTable Server = new DataTable();
            try
            {
                listView1.Clear();
                listView1.Columns.Add("Servicio", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Costo", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Descripcion", 100, HorizontalAlignment.Left);


                Server = ss.GetServicio();
                for (int i = 0; i < Server.Rows.Count; i++)
                {
                    DataRow dr = Server.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["NombreServicio"].ToString());
                    listitem.Tag = dr["idServicio"].ToString();
                    listitem.SubItems.Add(dr["costo"].ToString());
                    listitem.SubItems.Add(dr["descripcion"].ToString());

                    listView1.Items.Add(listitem);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CrearTabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaServicios Serv = new AltaServicios(0);
            Serv.ShowDialog();
            CrearTabla();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                AltaServicios Frm = new AltaServicios(Convert.ToInt32(listView1.SelectedItems[0].Tag));
                Frm.ShowDialog();
                CrearTabla();

            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione un registro");

            }
        }

        private void GestionServicios_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                int a = Convert.ToInt32(listView1.SelectedItems[0].Tag);
                if (MessageBox.Show("Se eliminara un registro", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Servicios Frm = new Servicios();
                    Frm.DelServicio(a);
                    CrearTabla();
                    MessageBox.Show("Registro eliminado");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione un registro");

            }
        }
    }
}
