using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG281_Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> userDetails = new Dictionary<string, string>();
            userDetails.Add("admin", "password");
            userDetails.Add("Thanos", "Inevitable");
            userDetails.Add("TestUser", "helloworld");

            try
            {
                if (userDetails.ContainsKey(txtUsername.Text) == false)
                {
                    throw new Exception();
                }
                else if (userDetails[txtUsername.Text] == txtPassword.Text)
                {
                    // This code hides the current login form and shows the sales form to the user.
                    this.Hide();
                    Form1 f2 = new Form1();
                    f2.ShowDialog();
                    this.Close();
                }
                else
                {
                    lblInvalidPass.Visible = true;
                    lblMessage.Visible = false;
                }
            }
            catch
            {
                lblMessage.Visible = true;
                lblInvalidPass.Visible = false;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
