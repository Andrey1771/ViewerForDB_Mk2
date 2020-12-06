using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Lab7_Bd_Mk2_Entity.Database.Tables;

namespace Lab7_Bd_Mk2_Entity.Database
{
    public class Database
    {
        private string connectionString = "";
        public bool connected = false;
        public string currentNameUser;
        MyConsole.MyConsole myConsole;

        private string nameDatabase;
        LinkedList<string> nameTables;

        LinkedList<bool> primaryKeysCurrentTable;
        LinkedList<string> nameColumnsCurrentTable;

        private void UpdateNameTables()
        {
            DataRowCollection dataRowCollection = GetRowsInRequest($"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = '{nameDatabase}';").Rows;
            if(nameTables != null)
                nameTables.Clear();
            foreach (DataRow row in dataRowCollection)
            {
                nameTables.AddLast(row[0].ToString());
            }
        }

        private bool UpdateCurrentTable(string nameTable)
        {
            DataRowCollection columnsDataRowCollection = GetRowsInRequest($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '{nameTable}'").Rows;
            if (nameColumnsCurrentTable == null)
                nameColumnsCurrentTable = new LinkedList<string>();
            else
                nameColumnsCurrentTable.Clear();

            foreach (DataRow row in columnsDataRowCollection)
            {
                nameColumnsCurrentTable.AddLast(row[0].ToString());
            }

            DataRowCollection primaryKeysDataRowCollection = GetRowsInRequest($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1 AND TABLE_NAME = '{nameTable}'").Rows;
            LinkedList<string> primaryColumnsNamesCollection = new LinkedList<string>();
            foreach (DataRow row in primaryKeysDataRowCollection)
            {
                primaryColumnsNamesCollection.AddLast(row[0].ToString());
            }

            if (primaryKeysCurrentTable == null)
                primaryKeysCurrentTable = new LinkedList<bool>();
            else
                primaryKeysCurrentTable.Clear();
            
            foreach(string var in nameColumnsCurrentTable)
            {
                if(nameColumnsCurrentTable.Find(var).Value != null)
                {
                    primaryKeysCurrentTable.AddLast(true);
                }
                else
                {
                    primaryKeysCurrentTable.AddLast(false);
                }
            }

            if(primaryKeysCurrentTable.Count != nameColumnsCurrentTable.Count)
            {
                myConsole.NewErrorMessage(@"Error \-_-/ primaryKeysCurrentTable.Count != nameColumnsCurrentTable.Count,
                                            UpdatePrimaryKeys(string tableName)");
                return false;
            }

            return true;
        }


        public LinkedList<string> GetColumnsTable(string nameTable)
        {
            UpdateCurrentTable(nameTable);
            return nameColumnsCurrentTable;
        }

        public LinkedList<string> GetNameTables()
        {
            return nameTables;
        }

        public Database(ref MyConsole.MyConsole amyConsole)
        {
            SetConsole(ref amyConsole);
        }

        public void SetConsole(ref MyConsole.MyConsole amyConsole)
        {
            myConsole = amyConsole;
        }

        public ref MyConsole.MyConsole GetMyConsole()
        {
            return ref myConsole;
        }

        public void OpenConnection(SqlConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch
            {
                connectionString = @"Error \-_-/";
                myConsole.NewErrorMessage(@"Error \-_-/ Connection failed");
                //throw new Exception("GetFlightRows(), Error");
            }
        }

        public LinkedList<string> GetNamesTablesDB()
        {
            LinkedList<string> tableNames = new LinkedList<string>();
            DataRowCollection dataRowCollection = GetRowsInRequest("SELECT Name FROM sys.Tables").Rows;
            foreach (DataRow row in dataRowCollection)
            {
                tableNames.AddLast((string)row[0]);
            }

            return tableNames;
        }

        //SELECT * FROM sys.database_principals where (type='S' or type = 'U')

        public LinkedList<UsersDatabaseRow> GetUsersTable()
        {
            LinkedList<UsersDatabaseRow> usersNames = new LinkedList<UsersDatabaseRow>();
            DataRowCollection dataRowCollection = GetRowsInRequest("SELECT name, principal_id, type, type_desc, default_schema_name, create_date, modify_date, authentication_type_desc FROM sys.database_principals WHERE (type='S' or type = 'U')").Rows;
            foreach (DataRow row in dataRowCollection)
            {
                string rowFifth = "";
                if (row[4] != DBNull.Value)
                    rowFifth = row[4].ToString();

                usersNames.AddLast(new UsersDatabaseRow((string)row[0] ?? "", (int)row[1], (string)row[2] ?? "",
                    (string)row[3] ?? "", rowFifth, (DateTime)row[5], (DateTime)row[6], (string)row[7] ?? ""));
            }

            return usersNames;
        }

        public bool MakeConnectDb(string login, string password)
        {
            currentNameUser = login;//DESKTOP-0U9RJHC\MSSQLSERVERNEW
            connectionString = $"Server=.\\SQLEXPRESS; Data Source=DESKTOP-0U9RJHC\\MSSQLSERVERNEW; Database=MS_SQL_Lab_2; User ID={login}; Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    UpdateNameTables();
                }
                catch (Exception e)
                {
                    connectionString = @"Error \-_-/";
                    myConsole.NewErrorMessage($"Error \\-_-/ Connection failed, {e.Message}");
                    return connected = false;
                }

                return connected = true;
            }
        }

        public bool MakeNewLoginToUser(string name, string password)
        {
            MakeRequest($"EXEC [AddLoginUser]('{name}', '{password}')");
            MakeRequest($"EXEC [AddRoleToUser]('{name}', 'Пассажир')");
            return true; // да, проверки пока нет, TODO добавить проверку
        }

        public void ChangeRoleUser(string name, string role)
        {
            MakeRequest($"EXEC [ChangeRole]('{name}', '{role}')");
        }

        private void MakeRequest(string request)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    OpenConnection(connection);

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = request;

                    try
                    {
                        cmd.ExecuteReader();//Reader надо поменять я забыл название 
                    }
                    catch (Exception e)
                    {
                        myConsole.NewErrorMessage($"Error \\-_-/ makeRequest({request}), {e.Message}");
                    }
                }
            }
            catch (Exception e)
            {
                myConsole.NewErrorMessage($"Error \\-_-/ makeRequest({request}), {e.Message}");
            }
        }

        public LinkedList<List<string>> GetRowsTable(string nameTable)
        {
            LinkedList<List<string>> rowsTableLinkList = new LinkedList<List<string>>();

            LinkedList<UsersDatabaseRow> usersNames = new LinkedList<UsersDatabaseRow>();
            DataRowCollection dataRowCollection = GetRowsInRequest($"SELECT * FROM {nameTable}").Rows;
            foreach (DataRow row in dataRowCollection)
            {
                object[] objects = row.ItemArray;
                List<string> rowStr = new List<string>();
                foreach(object cell in objects)
                {
                    rowStr.Add(cell.ToString());
                }
                rowsTableLinkList.AddLast(rowStr);
            }

            return rowsTableLinkList;
        }
        private DataTable GetRowsInRequest(string request)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    OpenConnection(connection);

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = request;

                    try
                    {
                        dataTable.Load(cmd.ExecuteReader());
                    }
                    catch (Exception e)
                    {
                        myConsole.NewErrorMessage($"Error \\-_-/ GetRowsInRequest({request}), {e.Message}");
                    }
                }
            }
            catch (Exception e)
            {
                myConsole.NewErrorMessage($"Error \\-_-/ GetRowsInRequest({request}), {e.Message}");
            }
            return dataTable;
        }

        //он должен быть приватный и не он должен использоваться TODO пофиксить это
        public void UpdateDataTable(string nameTable, string columnName, string newValue, string namePrimaryId, string primaryId)
        {
            MakeRequest($"UPDATE [{nameTable}] SET [{columnName}] = '{newValue}' WHERE [{namePrimaryId}] = {primaryId};");
        }

        public void DeleteDataTable(string nameTable, string namePrimaryId, string primaryId)
        {
            MakeRequest($"DELETE FROM [{nameTable}] WHERE [{namePrimaryId}] = {primaryId};");
        }

        //Функция и лучше не комментить
        public void InsertDataTable(string nameTable)
        {
            string request = "";
            switch (nameTable)
            {

                case "Рейс":
                    request = "SELECT MAX([ID Рейса] + 1) FROM [Рейс]";
                    if (GetRowsInRequest(request).Rows[0].Field<int?>(0) != null)
                        MakeRequest($"INSERT INTO [Рейс] VALUES({GetRowsInRequest(request).Rows[0].Field<int?>(0)}, 1, 1, 'Siberia', 1903, '14-11-2020 08:00:33', '14-11-2020 13:10:03')");
                    else
                        MakeRequest($"INSERT INTO [Рейс] VALUES({1}, 1, 1, 'Siberia', 1903, '14-11-2020 08:00:33', '14-11-2020 13:10:03')");
                    break;

                case "Владелец":
                    request = "SELECT MAX([ID Владельца] + 1) FROM [Владелец]";
                    if (GetRowsInRequest(request).Rows[0].Field<int?>(0) != null)
                        MakeRequest($"INSERT INTO [Владелец] VALUES({GetRowsInRequest(request).Rows[0].Field<int?>(0)}, 'Petr', 43, 811332, 'Kuznecsow')");
                    else
                        MakeRequest($"INSERT INTO [Владелец] VALUES({1}, 'Petr', 43, 811332, 'Kuznecsow')");
                    break;

                case "Авиакомпания":
                    request = "SELECT MAX([ID Авиакомпании] + 1) FROM [Авиакомпания]";
                    if (GetRowsInRequest(request).Rows[0].Field<int?>(0) != null)
                        MakeRequest($"INSERT INTO[Авиакомпания] VALUES({GetRowsInRequest(request).Rows[0].Field<int?>(0)}, 'Airlines', 'AirportLocation', '07-12-1941', 100)");
                    else
                        MakeRequest($"INSERT INTO[Авиакомпания] VALUES({1}, 'Airlines', 'AirportLocation', '07-12-1941', 100)");
                    break;

                case "Самолет":
                    request = "SELECT MAX([ID Самолета] + 1) FROM [Самолет]";
                    if (GetRowsInRequest(request).Rows[0].Field<int?>(0) != null)
                        MakeRequest($"INSERT INTO [Самолет] VALUES({GetRowsInRequest(request).Rows[0].Field<int?>(0)}, 1, 'Divine Wind', 'А6М2 Модель 21', '13-12-1941', 799999)");
                    else
                        MakeRequest($"INSERT INTO [Самолет] VALUES({1}, 1, 'Divine Wind', 'А6М2 Модель 21', '13-12-1941', 799999)");
                    break;
            }
        }

        public bool[] GetPrimaryKeysTable(string nameTable)
        {
            UpdateCurrentTable(nameTable);
            return primaryKeysCurrentTable.ToArray();
        }
    }
}
