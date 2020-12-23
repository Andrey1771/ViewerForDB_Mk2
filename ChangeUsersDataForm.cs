using System;
using System.Windows.Forms;
using Lab7_Bd.Database;

namespace Lab7_Bd
{
    public partial class ChangeUsersDataForm : Form
    {
        private Controller db;
        private TextBox oldOutputTextBox;

        public ChangeUsersDataForm(ref Controller adb)
        {
            db = adb;
            InitializeComponent();
            oldOutputTextBox = db.GetMyConsole().GetOutputTextBox();
            UpdateUsersDatabaseRowsDataGridView();
        }

        ~ChangeUsersDataForm()
        {
            db.GetMyConsole().SetConsoleOutput(ref oldOutputTextBox);
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
                ControllerUtilities inst = new ControllerUtilities(ref db.GetMyConsole());
                inst.UpdateUsersDatabaseRowsDataGridView(dataGridView1, db);
            }
        }
    }
}
