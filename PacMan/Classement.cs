using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    public partial class Classement : Form
    {
        public Classement()
        {
            InitializeComponent();
        }

        private void Classement_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show(this);
            this.Hide();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnretour.ForeColor = Color.SandyBrown;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnretour.ForeColor = Color.Black;
        }
    }
}
