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
            
            this.Hide();
            Form1 f2 = new Form1();
            f2.ShowDialog();
            this.Close();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> userDetails = new Dictionary<string, string>();
            userDetails.Add("admin", "password");
            userDetails.Add("Thanos", "Inevitable");
            userDetails.Add("TestUser", "helloworld");

            bool loginSuccess = false;
            while(loginSuccess == false)
            {
                if (userDetails.ContainsKey(txtUsername.Text))
                {
                    if (userDetails[txtUsername.Text] == txtPassword.Text)
                    {
                        this.Hide();
                        Form1 f2 = new Form1();
                        f2.ShowDialog();
                        this.Close();
                        loginSuccess = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid password. Please try again.");
                        break;
                    } 
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password. \n\nNote: Please ensure that Username and Password is capitalized correctly!");
                    break;
                }
            }

        }
    }
}
