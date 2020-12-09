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
        private Database.Database db;
        private TextBox oldOutputTextBox;

        public ChangeUsersDataForm(ref Database.Database adb)
        {
            db = adb;
            InitializeComponent();
            oldOutputTextBox = db.GetMyConsole().GetOutputTextBox();
            db.GetMyConsole().SetConsoleOutput(ref consoleLogTextBox);
            UpdateUsersDatabaseRowsDataGridView();
        }

        ~ChangeUsersDataForm()
        {
            db.GetMyConsole().SetConsoleOutput(ref oldOutputTextBox);
        }

        private void updateUsersButton_Click(object sender, EventArgs e)
        {
            UpdateUsersDatabaseRowsDataGridView();
        }

        public void UpdateUsersDatabaseRowsDataGridView()
        {
            if (db.connected)
            {
                DatabaseFormElementsInstruments inst = new DatabaseFormElementsInstruments(ref db.GetMyConsole());
                inst.UpdateUsersDatabaseRowsDataGridView(dataGridView1, db);
            }
        }
    }
}
