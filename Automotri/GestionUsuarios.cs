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
    public partial class GestionUsuarios : Form
    {
        public GestionUsuarios()
        {
            InitializeComponent();
        }
        public void cargar_datos()
        {
            Usuario us = new Usuario();
            DataTable empleados = new DataTable();
            try
            {
                listView1.Clear();
                listView1.Columns.Add("Nombre", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Paterno", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Materno", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Nacimiento", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Colonia", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Calle", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Puesto", 100, HorizontalAlignment.Left);
                empleados = us.get_US();
                for (int i = 0; i < empleados.Rows.Count; i++)
                {
                    DataRow dr = empleados.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["nombreEmpleado"].ToString());
                    listitem.Tag = dr["idEmpleado"].ToString();
                    listitem.SubItems.Add(dr["apellidoPaternoEmpleado"].ToString());
                    listitem.SubItems.Add(dr["apellidoMaternoEmpleado"].ToString());
                    listitem.SubItems.Add(dr["FechaNacimientoEmpleado"].ToString());

                    listitem.SubItems.Add(dr["colonia"].ToString());
                    listitem.SubItems.Add(dr["calle"].ToString());
                    listitem.SubItems.Add(dr["puesto"].ToString());
                    listView1.Items.Add(listitem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaUsuario AU = new AltaUsuario();
            AU.ShowDialog();
            cargar_datos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaUsuario AU = new AltaUsuario();
            AU.ID_US = Convert.ToInt32(listView1.SelectedItems[0].Tag);
            AU.ShowDialog();
            cargar_datos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Esta seguro de eliminar el Registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            Usuario u = new Usuario();
            if (dialogo == DialogResult.Yes)
            {
                u.eliminarUsuario(Convert.ToInt32(listView1.SelectedItems[0].Tag));
                cargar_datos();
            }
        }

        private void GestionUsuarios_Load_1(object sender, EventArgs e)
        {
            this.CenterToScreen();
            
            cargar_datos();

        }
    }
}
