using System;
using System.Linq;
using System.Windows.Forms;
using Lab7.Database;

namespace Lab7
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
    public partial class MainWindow : Form
    {
        private MyConsole.Log myConsole;
        private Database.Db db;
        private string currentTableName;
        private int selectedRowIndex = 0;
        public object oldCellEditData;

        public MainWindow()
        {
            InitializeComponent();
            myConsole = new MyConsole.Log(ref consoleLogTextBox);
            db = new Database.Db(ref myConsole);
        }

        //Обновление строк формы нашей таблицы
        private void UpdateFormRowsDataGridView(string tableName)
        {
            currentTableName = tableName;
            DbUtilities inst = new DbUtilities(ref myConsole);
            inst.UpdateDatabaseView(tableName, dataGridView1, db);
        }

        

        //Вызывающая функция при получении сигнала о нажатии на кнопку изменения роли пользователя, вызываем нашу форму
        private void changeRoleUser_Click(object sender, EventArgs e)
        {
            UsersWindow changeUsersDataForm = new UsersWindow(ref db);// Опять таки, сигналы неплохо бы зашли TODO Сделать с сигналами
            changeUsersDataForm.ShowDialog();
        }

        //Вызывающая функция при получении сигнала о нажатии на строку, запоминаем текущий индекс строки
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
        }


        //Вызывающая функция при получении сигнала о нажатии на кнопку добавления строки, совершаем запрос нашей БД
        private void insertRowButton_Click(object sender, EventArgs e)
        {
            db.InsertDataTable(currentTableName);
        }

        //Вызывающая функция при получении сигнала о нажатии на кнопку входа, обновляем данные таблицы
        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginWindow loginForm = new LoginWindow(ref db);// Опять таки, сигналы неплохо бы зашли TODO Сделать с сигналами
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

        //Вызывающая функция при получении сигнала о нажатии на кнопку удаления, совершаем запрос нашей БД на удаление
        private void deleteSelectedRowButton_Click_1(object sender, EventArgs e)
        {
            if (selectedRowIndex < dataGridView1.Rows.Count - 1)
            {
                db.DeleteDataTable(currentTableName, dataGridView1.Columns[0].Name, dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());
                //UpdateRowsDataGrid1(currentTableName);
            }
        }


        //Вызывающая функция при получении сигнала о начале редактирования ячейки, сохраняем значение изменяемой ячейки
        void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldCellEditData = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //accessIsShitPrimarykey = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        //Вызывающая функция при получении сигнала о нажатии на кнопку, обновляем нашу таблицу
        private void updateTableButton_Click(object sender, EventArgs e)
        {
            UpdateFormRowsDataGridView(namesTablesComboBox.SelectedItem?.ToString());//? - проверка на null )) i love С# <3
        }

        //Вызывающая функция при получении сигнала о выделении конкректного индекса в нашем комбобоксе, совершаем запрос нашей БД
        private void namesTablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFormRowsDataGridView(namesTablesComboBox.SelectedItem?.ToString());//? - проверка на null )) i love С# <3
        }
    }
}
