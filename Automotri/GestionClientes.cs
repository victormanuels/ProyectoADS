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
    public partial class GestionClientes : Form
    {
        public GestionClientes()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GestionClientes_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            
            Cliente cliente = new Cliente();
            DataTable clientes = new DataTable();
            try
            {
                lv.Clear();
                lv.Columns.Add("Nombre", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Paterno", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Materno", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Fecha de Nacimiento", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Calle", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Número", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Colonia", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Código Postal", 100, HorizontalAlignment.Left);
                lv.Columns.Add("Genero", 100, HorizontalAlignment.Left);
                clientes = cliente.get_AllCliente();
                for (int i = 0; i < clientes.Rows.Count; i++)
                {
                    DataRow dr = clientes.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["nombreCliente"].ToString());
                    listitem.Tag = dr["idCliente"].ToString();
                    listitem.SubItems.Add(dr["apellidoPaternoCliente"].ToString());
                    listitem.SubItems.Add(dr["apellidoMaternoCliente"].ToString());
                    listitem.SubItems.Add(dr["FechaNacimientoCliente"].ToString());
                    listitem.SubItems.Add(dr["calle"].ToString());
                    listitem.SubItems.Add(dr["numero"].ToString());
                    listitem.SubItems.Add(dr["colonia"].ToString());
                    listitem.SubItems.Add(dr["codigoPostal"].ToString());
                    if (dr["idGenero"].ToString() == "1")
                    {
                        listitem.SubItems.Add("Hombre");
                    }
                    else
                    {
                        listitem.SubItems.Add("Mujer");
                    }
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
            Cliente cliente = new Cliente();
            DialogResult dr = MessageBox.Show("¿Esta seguro que quiere eliminar dicho cliente?", "Eliminar Cliente", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cliente.eliminar_cliente(Convert.ToInt32(lv.SelectedItems[0].Tag));
                MessageBox.Show("Se ha eliminado!");
            }
            else if (dr == DialogResult.No)
            {
                MessageBox.Show("No se ha hecho nada.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                AltaClientes Frm3 = new AltaClientes();
                Frm3.idCliente = Convert.ToInt32(lv.SelectedItems[0].Tag);
                Frm3.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Un campo debe ser selecciónado!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaClientes frm = new AltaClientes();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }



    }
}