using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "kschmidt" && txtPassword.Text == "hello")
            {
                this.Close(); 

            }
            else
            {
                MessageBox.Show("Wrong username or password. Please try again.", "Error", MessageBoxButtons.OK);

            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            
        }
    }
}
