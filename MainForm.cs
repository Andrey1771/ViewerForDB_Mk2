using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab7_Bd_Mk2_Entity.Database;

namespace Lab7_Bd_Mk2_Entity
{

    //Важное пояснение:
    //Данная программа работает с БД !!!SQL Server!!!, возможно, любыми, возможно...
    //главная проблема может возникнуть при добавлении данных и их изменении,
    //тк данная прога не содержить модели для gridView, мой косяк, забыл, мог бы и сделать,
    //но она же работает?) (Использовать паттерн MVC)
    //РАБОТАЕТ ТОЛЬКО С ТАКИМИ ПОЛЯМИ int, nvarchar, money, datetime, date, Если есть другие
    //Нужно расширить switch в Database
    //у money есть баг при добавлении
    //Для смены подключаемой БД идти в  Database => public bool MakeConnectDb(string login, string password), 
    //Там все написано и очевидно, удачи!
    public partial class MainForm : Form
    {

        private Database.Database db;
        private string currentTableName;
        private int selectedRowIndex = 0;

        private MyConsole.MyConsole myConsole;

        public object oldCellEditData;

        public MainForm()
        {
            InitializeComponent();
            myConsole = new MyConsole.MyConsole(ref consoleLogTextBox);
            db = new Database.Database(ref myConsole);
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
            DatabaseFormElementsInstruments inst = new DatabaseFormElementsInstruments(ref myConsole);
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
            if (db.GetPrimaryKeysTable(currentTableName)[e.ColumnIndex] == true)
            {
                db.UpdateDataTable(currentTableName, dataGridView1.Columns[e.ColumnIndex].Name, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), dataGridView1.Columns[0].Name, oldCellEditData.ToString());// У всех первый элемент уникальный это первичный ключ
            }
            else
            {
                db.UpdateDataTable(currentTableName, dataGridView1.Columns[e.ColumnIndex].Name, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), dataGridView1.Columns[0].Name, dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
                //UpdateRowsDataGrid1(currentTableName);
        }

        
        void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldCellEditData = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void namesTablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFormRowsDataGridView(namesTablesComboBox.SelectedItem?.ToString());//? - проверка на null )) i love С# <3
        }
    }
}
