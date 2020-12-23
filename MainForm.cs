using System;
using System.Linq;
using System.Windows.Forms;
using Lab7_Bd.Database;

namespace Lab7_Bd
{
    public partial class MainForm : Form
    {

        private Database.Controller db;
        private string currentTableName;
        private int selectedRowIndex = 0;

        private MyConsole.Messager myConsole;

        public object oldCellEditData;

        public MainForm()
        {
            InitializeComponent();
            myConsole = new MyConsole.Messager(ref consoleLogTextBox);
            db = new Database.Controller(ref myConsole);
        }

        private void UpdateFormRowsDataGridView(string tableName)
        {
            currentTableName = tableName;
            ControllerUtilities inst = new ControllerUtilities(ref myConsole);
            inst.UpdateDatabaseRowsDataGridView(tableName, dataGridView1, db);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(ref db);// Опять таки, сигналы неплохо бы зашли TODO Сделать с сигналами
            loginForm.ShowDialog();
            if (db.connected)
            {
                namesTablesComboBox.Items.Clear();
                namesTablesComboBox.Items.AddRange(db.GetNamesTablesDB().ToArray());
                if (namesTablesComboBox.Items.Count > 0)
                {
                    namesTablesComboBox.SelectedItem = namesTablesComboBox.Items[0];
                    UpdateFormRowsDataGridView(namesTablesComboBox.Items[0].ToString());
                }
            }
        }

        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (db.GetPrimaryKeysTable(currentTableName)[e.ColumnIndex] == true)
            {
                db.UpdateDataTable(currentTableName, dataGridView1.Columns[e.ColumnIndex].Name, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), dataGridView1.Columns[0].Name, oldCellEditData.ToString());// У всех первый элемент уникальный это первичный ключ
            }
            else
            {
                db.UpdateDataTable(currentTableName, dataGridView1.Columns[e.ColumnIndex].Name, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), dataGridView1.Columns[0].Name, dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        
        void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldCellEditData = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

        //dataGrid
        private void updateTableButton_Click(object sender, EventArgs e)
        {
            UpdateFormRowsDataGridView(namesTablesComboBox.SelectedItem?.ToString());//? - проверка на null )) i love С# <3
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
        }

        //dataGrid
        private void insertRowButton_Click(object sender, EventArgs e)
        {
            db.InsertDataTable(currentTableName);
        }

        private void deleteSelectedRowButton_Click_1(object sender, EventArgs e)
        {
            if (selectedRowIndex < dataGridView1.Rows.Count - 1)
            {
                db.DeleteDataTable(currentTableName, dataGridView1.Columns[0].Name, dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());
            }
        }

        private void changeRoleUser_Click(object sender, EventArgs e)
        {
            ChangeUsersDataForm changeUsersDataForm = new ChangeUsersDataForm(ref db);// Опять таки, сигналы неплохо бы зашли TODO Сделать с сигналами
            changeUsersDataForm.ShowDialog();
        }


        private void namesTablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFormRowsDataGridView(namesTablesComboBox.SelectedItem?.ToString());//? - проверка на null )) i love С# <3
        }
    }
}
