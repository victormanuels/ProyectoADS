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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestionUsuarios frm = new GestionUsuarios();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GestionServicios frm = new GestionServicios();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GestionServiciosRealizados frm = new GestionServiciosRealizados();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GestionVentas frm = new GestionVentas();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GestionAutos frm = new GestionAutos();
            frm.ShowDialog();
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            GestionClientes frm = new GestionClientes();
            frm.ShowDialog();
        }


        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Size = new Size(212, 56);


        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Size = new Size(194, 38);


        }


        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Size = new Size(212, 56);

        }

        private void button2_MouseLeave_1(object sender, EventArgs e)
        {

            button2.Size = new Size(194, 38);

        }




        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.Size = new Size(212, 56);

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Size = new Size(194, 38);


        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.Size = new Size(212, 56);

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.Size = new Size(194, 38);


        }

    


        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.Size = new Size(212, 56);

        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.Size = new Size(194, 38);


        }



        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.Size = new Size(212, 56);

        }

       
        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.Size = new Size(194, 38);


        }

        private void button7_MouseHover(object sender, EventArgs e)
        {

        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.Size = new Size(194, 38);


        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

        }

   
       


    }
}
