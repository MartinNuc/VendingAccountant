using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using VendingAccountant.VendingServerService;

namespace VendingAccountant
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userDTO result;
            try
            {
                result = VendingService.getService().login(txtLogin.Text, txtPassword.Text);
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show("Server není dostupný.");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            // we let in just administrator or accountant
            if (result != null && (result.roleId == 5 || result.roleId == 1))
            {
                this.Visible = false;
                frmMain form = new frmMain();
                form.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Chybné příhlášení.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmFirstRun form = new frmFirstRun();
            this.Visible = false;
            form.ShowDialog();
            Close();
        }
    }
}
