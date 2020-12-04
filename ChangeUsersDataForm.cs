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
        private Database.Database database;

        public ChangeUsersDataForm(ref Database.Database adb)
        {
            db = adb;
            InitializeComponent();
            UpdateUsersDatabaseRowsDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void updateUsersButton_Click(object sender, EventArgs e)
        {
            UpdateUsersDatabaseRowsDataGridView();
        }

        public void UpdateUsersDatabaseRowsDataGridView()
        {
            if (db.connected)
            {
                DatabaseFormElementsInstruments inst = new DatabaseFormElementsInstruments();
                inst.UpdateUsersDatabaseRowsDataGridView(dataGridView1, db);
            }
        }
    }
}
