using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using Lab7.Database.Tables;

namespace Lab7.Database
{
    class DbUtilities
    {
        MyConsole.Log myConsole;

        public DbUtilities(ref MyConsole.Log amyConsole)
        {
            SetConsole(ref amyConsole);
        }

        //Установка используемой консоли
        public void SetConsole(ref MyConsole.Log amyConsole)
        {
            myConsole = amyConsole;
        }
        
        //Обновление данных в таблице Users
        public void UpdateUsersView(DataGridView dataGridView, Db db)
        {
            clearView(dataGridView);
            LinkedList<string[]> dataRows = new LinkedList<string[]>();

            LinkedList<UsersRow> tableUsers = db.GetUsersTable();

            foreach (UsersRow row in tableUsers)
            {
                dataRows.AddLast(row.GetStrArr());
            }
            UpdateView(dataGridView, UsersRow.namesColumn, dataRows);
        }

        //Очистка данных из БД
        public void clearView(DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
            }
            catch (Exception e)
            {
                myConsole.ErrorMessage($"Error! clearView(DataGridView dataGridView), {e.Message}");
            }
        }
        //Обновление данных в таблице
        private void UpdateView(DataGridView dataGridView, string[] nameColumns, LinkedList<string[]> dataRows)
        {
            BindingSource bindingSource = new BindingSource();
            DataTable dataTable = new DataTable();
            LinkedList<DataColumn> dataColumns = new LinkedList<DataColumn>();

            foreach (var name in nameColumns)
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


        //Обновление данных в конкретной таблице
        public void UpdateDatabaseView(string tableName, DataGridView dataGridView, Db db)
        {
            clearView(dataGridView);
            LinkedList<string[]> dataRows = new LinkedList<string[]>();

            LinkedList<List<string>> rowsTable = db.GetRowsTable(tableName);

            foreach (List<string> row in rowsTable)
            {
                dataRows.AddLast(row.ToArray());
            }
            UpdateView(dataGridView, db.GetColumnsTable(tableName).ToArray(), dataRows);
        }
    }
}
