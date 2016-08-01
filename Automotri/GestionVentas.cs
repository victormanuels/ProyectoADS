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
    public partial class GestionVentas : Form
    {
        public GestionVentas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaVenta venta = new AltaVenta();
            venta.ShowDialog();
            cargar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           int a =0 ;
            try
            {

                
                a= Convert.ToInt32(listView1.SelectedItems[0].Tag);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione una venta");
            }

            if(a!=0){
                 AltaVenta venta = new AltaVenta();
                venta.ID_ven = a;

                venta.ShowDialog();
                 cargar();
            }
           
        }

        private void GestionVentas_Load(object sender, EventArgs e)
        {
            cargar();
        }
        public void cargar()
        {
            venta v = new venta();
            DataTable empleados = new DataTable();
            try
            {
                listView1.Clear();
                listView1.Columns.Add("Fecha", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Empleado", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Cliente", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Automovil", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Descripcion", 100, HorizontalAlignment.Left);

                empleados = v.get_ven();
                for (int i = 0; i < empleados.Rows.Count; i++)
                {
                    DataRow dr = empleados.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["fechaVenta"].ToString());
                    listitem.Tag = dr["idVenta"].ToString();
                    listitem.SubItems.Add(dr["apellidoPaternoEmpleado"].ToString());
                    listitem.SubItems.Add(dr["apellidoPaternoCliente"].ToString());
                    listitem.SubItems.Add(dr["modelo"].ToString());
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

        private void button3_Click(object sender, EventArgs e)
        {
           
               
                try
                {
                    DialogResult dialogo = MessageBox.Show("¿Esta seguro de eliminar el Registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    venta v = new venta();
                    if (dialogo == DialogResult.Yes)
                    {
                    v.cancelacion(Convert.ToInt32(listView1.SelectedItems[0].Tag));
                    cargar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Seleccione un registro");
                }


            
        }

        private void GestionVentas_Load_1(object sender, EventArgs e)
        {
            this.CenterToScreen();
            
            cargar();

        }
    }
}
