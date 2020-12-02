using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab7_Bd_Mk2_Entity.Database;

namespace Lab7_Bd_Mk2_Entity
{
    public partial class ChangeUsersDataForm : Form
    {
        public ChangeUsersDataForm(ref Database.Database db)
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void updateUsersButton_Click(object sender, EventArgs e)
        {
            //SELECT * FROM sys.database_principals where (type='S' or type = 'U')
        }
    }
}
