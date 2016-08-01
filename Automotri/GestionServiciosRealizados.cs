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
    public partial class GestionServiciosRealizados : Form
    {
        public GestionServiciosRealizados()
        {
            InitializeComponent();
        }


        private void CrearTabla(){
            Servicios ss = new Servicios();
            DataTable Server = new DataTable();
            try
            {
                listView1.Clear();
                listView1.Columns.Add("Cliente", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Categoria auto", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Servicio", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Costo", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Estado", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Fecha pedido", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Fecha realizado", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Descripcion", 100, HorizontalAlignment.Left);


                Server = ss.getServiciosRealizados();
                for (int i = 0; i < Server.Rows.Count; i++)
                {
                    DataRow dr = Server.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["nombrec"].ToString());
                    listitem.Tag = dr["idServicioRealizado"].ToString();
                    listitem.SubItems.Add(dr["categoria"].ToString());
                    listitem.SubItems.Add(dr["NombreServicio"].ToString());
                    listitem.SubItems.Add(dr["costo"].ToString());
                    listitem.SubItems.Add(dr["estado"].ToString());
                    listitem.SubItems.Add(dr["fechapedido"].ToString());
                    listitem.SubItems.Add(dr["fecharealizado"].ToString());
                    listitem.SubItems.Add(dr["Descripcion"].ToString());

                    listView1.Items.Add(listitem);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }


        }

        private void GestionServiciosRealizados_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            
            CrearTabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaServiciosRealizados al = new AltaServiciosRealizados(0);

            al.ShowDialog();
            CrearTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DateTime fechapedido = new DateTime(2008, 12, 24);

            try
            {
               

                Servicios ser = new Servicios();
                ser.AnadirServicioRealizado(Convert.ToInt32(listView1.SelectedItems[0].Tag), 0, 0, 0, fechapedido);

                CrearTabla();
                MessageBox.Show("Servicio completado con exito");

            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione un servicio");

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Servicios ser = new Servicios();
            int id=1;
            try
            {

                 id = Convert.ToInt32(listView1.SelectedItems[0].Tag);

                 ser.EliminarServicioRealizado(id);

                 CrearTabla();
                MessageBox.Show("Servicio eliminado con exito");

            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione un servicio");

            }

           
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
