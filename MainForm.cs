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
using Stas.Database;

namespace Stas
{
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

        //Обновление строк формы нашей таблицы
        private void UpdateFormRowsDataGridView(string tableName)
        {
            currentTableName = tableName;
            DatabaseFormElementsInstruments inst = new DatabaseFormElementsInstruments(ref myConsole);
            inst.UpdateDatabaseRowsDataGridView(tableName, dataGridView1, db);
        }

        //Вызывающая функция при получении сигнала о нажатии на кнопку входа, обновляем данные таблицы
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

        //Вызывающая функция при получении сигнала о окончании редактирования ячейки, обновляем данные
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

        //Вызывающая функция при получении сигнала о начале редактирования ячейки, сохраняем значение изменяемой ячейки
        void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldCellEditData = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //accessIsShitPrimarykey = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        //dataGrid
        //Вызывающая функция при получении сигнала о нажатии на кнопку, обновляем нашу таблицу
        private void updateTableButton_Click(object sender, EventArgs e)
        {
            UpdateFormRowsDataGridView(namesTablesComboBox.SelectedItem?.ToString());//? - проверка на null )) i love С# <3
        }

        //Вызывающая функция при получении сигнала о нажатии на строку, запоминаем текущий индекс строки
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
        }

        //dataGrid
        //Вызывающая функция при получении сигнала о нажатии на кнопку добавления строки, совершаем запрос нашей БД
        private void insertRowButton_Click(object sender, EventArgs e)
        {
            db.InsertDataTable(currentTableName);
        }

        //Вызывающая функция при получении сигнала о нажатии на кнопку удаления, совершаем запрос нашей БД на удаление
        private void deleteSelectedRowButton_Click_1(object sender, EventArgs e)
        {
            if (selectedRowIndex < dataGridView1.Rows.Count - 1)
            {
                db.DeleteDataTable(currentTableName, dataGridView1.Columns[0].Name, dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());
                //UpdateRowsDataGrid1(currentTableName);
            }
        }

        //Вызывающая функция при получении сигнала о нажатии на кнопку изменения роли пользователя, вызываем нашу форму
        private void changeRoleUser_Click(object sender, EventArgs e)
        {
            ChangeUsersDataForm changeUsersDataForm = new ChangeUsersDataForm(ref db);// Опять таки, сигналы неплохо бы зашли TODO Сделать с сигналами
            changeUsersDataForm.ShowDialog();
        }

        //Вызывающая функция при получении сигнала о выделении конкректного индекса в нашем комбобоксе, совершаем запрос нашей БД
        private void namesTablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFormRowsDataGridView(namesTablesComboBox.SelectedItem?.ToString());//? - проверка на null )) i love С# <3
        }
    }
}
