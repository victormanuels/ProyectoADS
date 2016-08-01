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
    public partial class Login : Form
    {
        public Login()
        {

            InitializeComponent();


        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.CenterToScreen() ;
            }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
             Usuario usua = new Usuario();
            bool c = usua.Chc_Usuario(textBox2.Text, textBox1.Text);
            if (c == true)
            {
                Menu menu = new Menu();
                menu.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("usuario no encontrado");
            }
             */
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
