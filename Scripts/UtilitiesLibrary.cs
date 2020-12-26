using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Stas.Database.Tables;
using System.Data;

namespace Stas.Database
{
    class DatabaseFormElementsInstruments
    {
        MyConsole.MyConsole myConsole;

        public DatabaseFormElementsInstruments(ref MyConsole.MyConsole amyConsole)
        {
            SetConsole(ref amyConsole);
        }

        //Установка используемой консоли
        public void SetConsole(ref MyConsole.MyConsole amyConsole)
        {
            myConsole = amyConsole;
        }
        //Очистка данных из БД
        public void clearDataGridView(DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
            }
            catch (Exception e)
            {
                //myConsole.NewErrorMessage($"Error \\-_-/ clearDataGridView(DataGridView dataGridView), {e.Message}");
            }
        }

        //В идеале надо было разделить отображение от данных и перенести некоторые функции в отдельный класс
        //Обновление данных в таблице
        private void UpdateRowsDataGridView(DataGridView dataGridView, string[] nameColumns, LinkedList<string[]> dataRows)
        {
            BindingSource bindingSource = new BindingSource();
            DataTable dataTable = new DataTable();
            LinkedList<DataColumn> dataColumns = new LinkedList<DataColumn>();

            foreach(var name in nameColumns)
            {
                dataColumns.AddLast(new DataColumn(name));
            }
            
            dataTable.Columns.AddRange(dataColumns.ToArray());
            foreach (var row in dataRows)
            {
                dataTable.Rows.Add(row);
            }
            
            bindingSource.DataSource = dataTable;
            dataGridView.DataSource = bindingSource;
        }

        //Обновление данных в таблице Users
        public void UpdateUsersDatabaseRowsDataGridView(DataGridView dataGridView, Database db)
        {
            clearDataGridView(dataGridView);
            LinkedList<string[]> dataRows = new LinkedList<string[]>();

            LinkedList<UsersDatabaseRow> tableUsers = db.GetUsersTable();

            foreach (UsersDatabaseRow row in tableUsers)
            {
                dataRows.AddLast(row.GetArrayStr());
            }
            UpdateRowsDataGridView(dataGridView, UsersDatabaseRow.namesColumn, dataRows);
        }

        //Обновление данных в конкретной таблице
        public void UpdateDatabaseRowsDataGridView(string tableName, DataGridView dataGridView, Database db)
        {
            clearDataGridView(dataGridView);
            LinkedList<string[]> dataRows = new LinkedList<string[]>();

            LinkedList<List<string>> rowsTable = db.GetRowsTable(tableName);

            foreach (List<string> row in rowsTable)
            {
                dataRows.AddLast(row.ToArray());
            }
            UpdateRowsDataGridView(dataGridView, db.GetColumnsTable(tableName).ToArray(), dataRows);
        }
    }
}
