using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace VendingAccountant
{
    public partial class frmFirstRun : Form
    {
        public frmFirstRun()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // save server ip
            Microsoft.Win32.RegistryKey registry = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("Vending");
            if (registry == null)
            {
                MessageBox.Show("Nemáte dostatečná práva pro provoz aplikace. Kontaktujte administrátora.");
                this.Close();
            }
            registry.SetValue("ServerIp", txtIp.Text);
            registry.Close();

            // try to register product
            Boolean result;
            try
            {
                result = VendingService.getService().isRegistered();
            }
            catch (FaultException)
            {
                result = false;
            }

            if (result == true)
            {
                // register first user
                frmLogin form = new frmLogin();
                this.Visible = false;
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Aplikace není registrovaná nebo se nelze k serveru připojit.\r\n\r\nRegistrujte aplikaci přes administrační rozhraní.");
            }
        }
    }
}
