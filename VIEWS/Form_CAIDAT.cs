using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DarkUI.Forms;
using MySqlConnector;

namespace HCE_QTCSVC_CLIENT.VIEW
{
    public partial class Form_CAIDAT : DarkForm
    {
        public Form_CAIDAT()
        {
            InitializeComponent();
        }

        private void Button_KIEMTRASQL_Click(object sender, EventArgs e)
        {
            if (DBConnection.TestConnection())
            {
                MessageBox.Show("Kêt nối CSDL Biostar2 thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kêt nối thất bại..,!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_LUU_Click(object sender, EventArgs e)
        {
            // Retrieve the current configuration
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Get the connection strings section
            ConnectionStringsSection connectionStringsSection = config.ConnectionStrings;


            // Update the connection string values
            connectionStringsSection.ConnectionStrings["BioStar2ConnectionString"].ConnectionString = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};",
                TBox_HOST.Text,
                TBox_PORT.Text,
                TBox_DATABASE.Text,
                TBox_TAIKHOAN.Text,
                TBox_MATKHAU.Text);

            // Save the changes to the configuration file
            config.Save(ConfigurationSaveMode.Modified);

            // Refresh the configuration manager
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        private void Button_HUY_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_CAIDAT_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BioStar2ConnectionString"].ConnectionString;
            var builder = new MySqlConnectionStringBuilder(connectionString);

            TBox_HOST.Text = builder.Server;
            TBox_PORT.Text = builder.Port.ToString();
            TBox_DATABASE.Text = builder.Database;
            TBox_TAIKHOAN.Text = builder.UserID;
            TBox_MATKHAU.Text = builder.Password;
        }
    }
}
