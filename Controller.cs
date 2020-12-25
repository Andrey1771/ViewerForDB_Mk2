using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace Lab7_Bd.Controller
{
    public class Controller
    {
        private string connectStr = "";
        public bool connected = false;
        LinkedList<bool> primaryKeysCurrentTable;
        LinkedList<string> nameColumnsCurrentTable;
        public string currentNameUser;
        Messager.Messager Messager;
        private string nameDatabase;
        LinkedList<string> nameTables;
        LinkedList<string> typeColumnsCurrentTable;

        public static string[] UsersNamesColumn = new string[] { "name", "principal_id", "type",
        "type_desc", "default_schema_name", "create_date", "modify_date",
            "authentication_type_desc" };

        //Защита от SQL инъекций, если символ отсутствует из разрешеннных, метод вернет false
        private bool IsLegalQuery(string strText)
        {
            bool islegal = false;
            char symbol = ' ';
            if (strText.Length > 0)
            {
                //Это массив разрешенных символов
                char[] legalchars = @"«ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУ
    ФХЦЧШЩЭЫЪЬЮЯабвгдеёжзийклмнопрстуфхцчшщэъьыюя01234567890., „_".ToCharArray();
                islegal = true;
                // посимвольно проверяем пришедший string
                for (int i = 0; i < strText.Length; i++)
                {
                    // если символ в строке отсутсвет в массиве разрешенных, возвращаем false
                    if (strText.LastIndexOfAny(legalchars, i, 1) < 0)
                    {
                        islegal = false;
                        symbol = strText[i];
                        break;
                    }
                }
            }
            if (!islegal)
                Messager.NewErrorMessage($"Error \\-_-/ Использованы недопустимые символ, Строка: {strText}, Символ: {symbol}");
            return islegal;
        }



        private void UpdateNameTables()
        {
            DataRowCollection dataRowCollection = GetRowsInRequest($"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = '{nameDatabase}';").Rows;
            if (nameTables != null)
                nameTables.Clear();
            else
                nameTables = new LinkedList<string>();
            foreach (DataRow row in dataRowCollection)
            {
                nameTables.AddLast(row[0].ToString());
            }

            DataRowCollection nameViewDataRowCollection = GetRowsInRequest($"SELECT name FROM sys.views;").Rows;

            foreach (DataRow row in nameViewDataRowCollection)
            {
                nameTables.AddLast(row[0].ToString());
            }

        }

        private bool UpdateCurrentTable(string nameTable)
        {
            if (!IsLegalQuery(nameTable))
            {
                return false;
            }
            DataRowCollection columnsDataRowCollection = GetRowsInRequest($"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '{nameTable}';").Rows;
            if (nameColumnsCurrentTable == null)
                nameColumnsCurrentTable = new LinkedList<string>();
            else
                nameColumnsCurrentTable.Clear();

            if (typeColumnsCurrentTable == null)
                typeColumnsCurrentTable = new LinkedList<string>();
            else
                typeColumnsCurrentTable.Clear();

            foreach (DataRow row in columnsDataRowCollection)
            {
                nameColumnsCurrentTable.AddLast(row[0].ToString());
                typeColumnsCurrentTable.AddLast(row[1].ToString());
            }

            DataRowCollection primaryKeysDataRowCollection = GetRowsInRequest($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1 AND TABLE_NAME = '{nameTable}';").Rows;
            LinkedList<string> primaryColumnsNamesCollection = new LinkedList<string>();
            foreach (DataRow row in primaryKeysDataRowCollection)
            {
                primaryColumnsNamesCollection.AddLast(row[0].ToString());
            }

            if (primaryKeysCurrentTable == null)
                primaryKeysCurrentTable = new LinkedList<bool>();
            else
                primaryKeysCurrentTable.Clear();

            foreach (string var in nameColumnsCurrentTable)
            {
                bool ok = false;
                foreach (string var2 in primaryColumnsNamesCollection)
                {
                    if (var == var2)
                    {
                        primaryKeysCurrentTable.AddLast(true);
                        ok = true;
                        break;
                    }
                }
                if(!ok)
                    primaryKeysCurrentTable.AddLast(false);
            }

            if (primaryKeysCurrentTable.Count != nameColumnsCurrentTable.Count)
            {
                Messager.NewErrorMessage(@"Error \-_-/ primaryKeysCurrentTable.Count != nameColumnsCurrentTable.Count,
                                            UpdatePrimaryKeys(string tableName)");
                return false;
            }

            return true;
        }


     

        public ref Messager.Messager GetMyConsole()
        {
            return ref Messager;
        }

        public void OpenConnection(SqlConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch
            {
                connectStr = @"Error \-_-/";
                Messager.NewErrorMessage(@"Error \-_-/ Connection failed");
            }
        }

        public LinkedList<string> GetNamesTablesDB()
        {
            UpdateNameTables();
            return GetNameTables();
        }


        public LinkedList<List<string>> GetUsersTable()
        {
            LinkedList<List<string>> rowsTableLinkList = new LinkedList<List<string>>();

            DataRowCollection dataRowCollection = GetRowsInRequest($"SELECT name, principal_id, type, type_desc, default_schema_name, create_date, modify_date, authentication_type_desc FROM sys.database_principals WHERE(type = 'S' or type = 'U');").Rows;
            foreach (DataRow row in dataRowCollection)
            {
                object[] objects = row.ItemArray;
                List<string> rowStr = new List<string>();
                foreach (object cell in objects)
                {
                    rowStr.Add(cell.ToString());
                }
                rowsTableLinkList.AddLast(rowStr);
            }

            return rowsTableLinkList;
        }

        public bool MakeConnect(string login, string password)
        {
            if (!IsLegalQuery(login) || !IsLegalQuery(password))
            {
                return false;
            }
            currentNameUser = login;
            nameDatabase = "DB_S";
            connectStr = $"Server=.\\SQLEXPRESS; AttachDbFilename=C:\\Program Files\\Microsoft SQL Server\\MSSQL14.SQLEXPRESS\\MSSQL\\DATA\\DB_S.mdf; Database='{nameDatabase}'; Trusted_Connection=Yes; User ID='{login}'; Password='{password}'; ";
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                try
                {
                    connection.Open();
                    UpdateNameTables();
                }
                catch (Exception e)
                {
                    connectStr = @"Error \-_-/";
                    Messager.NewErrorMessage($"Error \\-_-/ Connection failed, {e.Message}");
                    return connected = false;
                }

                return connected = true;
            }
        }

        public bool MakeNewLoginToUser(string name, string password, string role)
        {
            if (!IsLegalQuery(name) || !IsLegalQuery(password) || !IsLegalQuery(role))
            {
                return false;
            }
            MakeRequest($"EXEC sp_addlogin '{name}', '{password}', '{nameDatabase}'");
            MakeRequest($"EXEC sp_adduser '{name}'");
            MakeRequest($"EXEC sp_addrolemember '{role}', '{name}'");

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

        public Controller(ref Messager.Messager amyConsole)
        {
            SetConsole(ref amyConsole);
        }

        public void SetConsole(ref Messager.Messager amyConsole)
        {
            Messager = amyConsole;
        }

        private void MakeRequest(string request)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectStr))
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
                        Messager.NewErrorMessage($"Error \\-_-/ makeRequest({request}), {e.Message}");
                    }
                }
            }
            catch (Exception e)
            {
                Messager.NewErrorMessage($"Error \\-_-/ makeRequest({request}), {e.Message}");
            }
        }

        public LinkedList<List<string>> GetRowsTable(string nameTable)
        {
            LinkedList<List<string>> rowsTableLinkList = new LinkedList<List<string>>();

            DataRowCollection dataRowCollection = GetRowsInRequest($"SELECT * FROM {nameTable};").Rows;
            foreach (DataRow row in dataRowCollection)
            {
                object[] objects = row.ItemArray;
                List<string> rowStr = new List<string>();
                foreach (object cell in objects)
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
                using (SqlConnection connection = new SqlConnection(connectStr))
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
                        Messager.NewErrorMessage($"Error \\-_-/ GetRowsInRequest({request}), {e.Message}");
                    }
                }
            }
            catch (Exception e)
            {
                Messager.NewErrorMessage($"Error \\-_-/ GetRowsInRequest({request}), {e.Message}");
            }
            return dataTable;
        }

        //он должен быть приватный и не он должен использоваться TODO пофиксить это
        public void UpdateDataTable(string nameTable, string columnName, string newValue, string namePrimaryId, string primaryId)
        {
            if (!IsLegalQuery(nameTable) || !IsLegalQuery(columnName) || !IsLegalQuery(newValue) || !IsLegalQuery(namePrimaryId) || !IsLegalQuery(primaryId))
            {
                return;
            }
            MakeRequest($"UPDATE [{nameTable}] SET [{columnName}] = '{newValue}' WHERE [{namePrimaryId}] = {primaryId};");
        }

        public void DeleteDataTable(string nameTable, string namePrimaryId, string primaryId)
        {
            if (!IsLegalQuery(nameTable) || !IsLegalQuery(namePrimaryId) || !IsLegalQuery(primaryId))
            {
                return;
            }
            MakeRequest($"DELETE FROM [{nameTable}] WHERE [{namePrimaryId}] = {primaryId};");
        }

        //Функция и лучше не комментить
        public void InsertDataTable(string nameTable)
        {

            string request = "";
            UpdateCurrentTable(nameTable);

            int i = 0;
            string insertValues = "";
            foreach (string var in nameColumnsCurrentTable)
            {

                request = $"SELECT MAX([{var.ToString()}]) FROM [{nameTable}];";

                //request = $"SELECT MAX([{var.ToString()}]) FROM [{nameTable}]";
                object obj = GetRowsInRequest(request).Rows[0].Field<object>(0);
                if (obj != null)
                {
                    switch (typeColumnsCurrentTable.ElementAt(i))//Тут появляется ограничение на тип допустимых данных в таблицах
                    {
                        case "int":
                            if(primaryKeysCurrentTable.ElementAt(i))
                                insertValues += $"{(int)obj + 1},";
                            else
                                insertValues += $"{(int)obj},";
                            break;
                        case "real":
                            insertValues += $"'{(decimal)obj}',";
                            break;
                        case "nvarchar":
                            insertValues += $"'{(string)obj}',";
                            break;
                        case "varchar":
                            insertValues += $"'{(string)obj}',";
                            break;
                        case "char":
                            insertValues += $"'{(string)obj}',";
                            break;
                        case "nchar":
                            insertValues += $"'{(string)obj}',";
                            break;
                        case "money":
                            insertValues += $"'{1}',";
                            break;
                        case "datetime":
                            insertValues += $"'{obj.ToString()}',";
                            break;
                        case "date":
                            insertValues += $"'{obj.ToString()}',";
                            break;
                        default:
                            Messager.NewErrorMessage(@"Error \-_-/ такого тип не поддерживается, InsertDataTable(string nameTable)");
                            break;
                    }
                }
                else
                {
                    switch (typeColumnsCurrentTable.ElementAt(i))
                    {
                        case "int":
                            insertValues += $"{1},";
                            break;
                        case "real":
                            insertValues += $"'{1}',";
                            break;
                        case "nvarchar":
                            insertValues += $"'{""}',";
                            break;
                        case "varchar":
                            insertValues += $"'{""}',";
                            break;
                        case "char":
                            insertValues += $"'{""}',";
                            break;
                        case "nchar":
                            insertValues += $"'{""}',";
                            break;
                        case "money":
                            insertValues += $"{1},";
                            break;
                        case "datetime":
                            insertValues += $"'{"2020-11-14 08:00:33.000"}',";
                            break;
                        case "date":
                            insertValues += $"'{"2020-11-14"}',";
                            break;
                        default:
                            Messager.NewErrorMessage(@"Error \-_-/ такой тип не поддерживается, InsertDataTable(string nameTable)");
                            break;
                    }
                }
                ++i;
            }
            insertValues = insertValues.Remove(insertValues.Count() - 1, 1);
            MakeRequest($"INSERT INTO [{nameTable}] VALUES({insertValues});");
        }



        public bool[] GetPrimaryKeysTable(string nameTable)
        {

            UpdateCurrentTable(nameTable);
            return primaryKeysCurrentTable.ToArray();
        }
    }
}
