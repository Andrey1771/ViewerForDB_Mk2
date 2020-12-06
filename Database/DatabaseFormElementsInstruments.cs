using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab7_Bd_Mk2_Entity.Database;
using Lab7_Bd_Mk2_Entity.Database.Tables;

namespace Lab7_Bd_Mk2_Entity.Database
{
    class DatabaseFormElementsInstruments
    {
        MyConsole.MyConsole myConsole;
        public DatabaseFormElementsInstruments(ref MyConsole.MyConsole amyConsole)
        {
            SetConsole(ref amyConsole);
        }

        public void SetConsole(ref MyConsole.MyConsole amyConsole)
        {
            myConsole = amyConsole;
        }

        public void clearDataGridView(DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
            }
            catch (Exception e)
            {
                myConsole.NewErrorMessage($"Error \\-_-/ clearDataGridView(DataGridView dataGridView), {e.Message}");
            }
        }

        //В идеале надо было разделить отображение от данных и перенести некоторые функции в отдельный класс

        private void UpdateRowsDataGridView(DataGridView dataGridView, string[] nameColumns, LinkedList<string[]> dataRows)
        {

            foreach (string name in nameColumns)
            {
                DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
                dataGridViewColumn.HeaderText = name;
                dataGridViewColumn.Name = name;
                dataGridView.Columns.Add(dataGridViewColumn);
            }
            foreach (string[] row in dataRows)
            {
                dataGridView.Rows.Add(row);
            }
        }

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
