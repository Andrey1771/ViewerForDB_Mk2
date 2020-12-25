using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab7_Bd.Controller
{
    class ControllerUtilities
    {
        Messager.Messager Messager;
        
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

        public void UpdateUsersDatabaseRowsDataGridView(DataGridView dataGridView, Controller db)
        {
            clearDataGridView(dataGridView);
            LinkedList<string[]> dataRows = new LinkedList<string[]>();

            LinkedList<List<string>> tableUsers = db.GetUsersTable();

            foreach (List<string> row in tableUsers)
            {
                dataRows.AddLast(row.ToArray());
            }
            UpdateRowsDataGridView(dataGridView, Controller.UsersNamesColumn, dataRows);
        }

        public ControllerUtilities(ref Messager.Messager amyConsole)
        {
            SetConsole(ref amyConsole);
        }

        public void SetConsole(ref Messager.Messager amyConsole)
        {
            Messager = amyConsole;
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
                Messager.NewErrorMessage($"Error \\-_-/ clearDataGridView(DataGridView dataGridView), {e.Message}");
            }
        }
        public void UpdateDatabaseRowsDataGridView(string tableName, DataGridView dataGridView, Controller db)
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
