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
    public partial class MainForm : Form
    {

        private Database.Database db;
        private string currentTableName;
        private int selectedRowIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            db = new Database.Database();
        }


        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateFormRowsDataGridView(string tableName)
        {
            currentTableName = tableName;
            DatabaseFormElementsInstruments inst = new DatabaseFormElementsInstruments();
            inst.UpdateDatabaseRowsDataGridView(tableName, dataGridView1, db);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(ref db);// Опять таки, сигналы неплохо бы зашли TODO Сделать с сигналами
            loginForm.ShowDialog();
            if (db.connected)
            {
                nameUserTextBox.Text = db.currentNameUser;
                namesTablesComboBox.Items.Clear();
                namesTablesComboBox.Items.AddRange(db.GetNamesTablesDB().ToArray());
                if (namesTablesComboBox.Items.Count > 0)
                {
                    namesTablesComboBox.SelectedItem = namesTablesComboBox.Items[0];
                    UpdateFormRowsDataGridView(namesTablesComboBox.Items[0].ToString());
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            db.UpdateDataTable(currentTableName, dataGridView1.Columns[e.ColumnIndex].Name, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), dataGridView1.Columns[0].Name, dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());// У всех первый элемент уникальный это первичный ключ
            //UpdateRowsDataGrid1(currentTableName);
        }

        void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //accessIsShitPrimarykey = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void fillColumnNameDataGridView()
        {
            dataGridView1.Columns.AddRange();
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
                //UpdateRowsDataGrid1(currentTableName);
            }
        }

        private void changeRoleUser_Click(object sender, EventArgs e)
        {
            ChangeUsersDataForm changeUsersDataForm = new ChangeUsersDataForm(ref db);// Опять таки, сигналы неплохо бы зашли TODO Сделать с сигналами
            changeUsersDataForm.ShowDialog();
        }


    }


}
