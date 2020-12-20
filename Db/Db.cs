using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Lab7.Database.Tables;

namespace Lab7.Database
{
    public class Db
    {
        LinkedList<bool> primaryKeysCurrentTable;
        LinkedList<string> nameColumnsCurrentTable;
        LinkedList<string> typeColumnsCurrentTable;
        
        public string currentNameUser;
        private string connectionString = "";
        public bool connected = false;
        
        private string nameDatabase;
        LinkedList<string> nameTables;
        MyConsole.Log myConsole;

        //Защита от SQL инъекций, если символ отсутствует из разрешеннных, метод вернет false
        private bool IsLegalQuery(string strText)
        {
            bool islegal = false;
            char symbol = ' ';
            if (strText.Length > 0)
            {
                char[] legalchars = @"«ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУ
    ФХЦЧШЩЭЫЪЬЮЯабвгдеёжзийклмнопрстуфхцчшщэъьыюя01234567890., „".ToCharArray();
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
                myConsole.ErrorMessage($"Error \\-_-/ Использованы недопустимые символ, Строка: {strText}, Символ: {symbol}");
            return islegal;
        }


        //Получение названия колонок с помощью двусвязного списка
        public LinkedList<string> GetColumnsTable(string nameTable)
        {
            UpdateCurrentTable(nameTable);
            return nameColumnsCurrentTable;
        }

        //Получение названия таблиц нашей БД
        public LinkedList<string> GetNameTables()
        {
            return nameTables;
        }

        
        //Получение текущей консоли через ссылку 
        public ref MyConsole.Log GetMyConsole()
        {
            return ref myConsole;
        }

        //Обновление названия таблиц, данные берем из запроса
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

        //Конструктор, что тут сказать
        public Db(ref MyConsole.Log amyConsole)
        {
            SetConsole(ref amyConsole);
        }

        //Установка консоли
        public void SetConsole(ref MyConsole.Log amyConsole)
        {
            myConsole = amyConsole;
        }


        //Обновление текущей переданной по названию таблицы через запрос 
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
                if (!ok)
                    primaryKeysCurrentTable.AddLast(false);
            }

            if (primaryKeysCurrentTable.Count != nameColumnsCurrentTable.Count)
            {
                myConsole.ErrorMessage(@"UpdatePrimaryKeys(string tableName)");
                return false;
            }

            return true;
        }

        //Открытие соединения с БД и проверка на открытость
        public void OpenConnection(SqlConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch
            {
                connectionString = @"Error";
                myConsole.ErrorMessage(@"Error Connection failed");
                //throw new Exception("GetFlightRows(), Error");
            }
        }

        //Получение первичных ключей нашей таблицы
        public bool[] GetPrimaryKeysTable(string nameTable)
        {
            UpdateCurrentTable(nameTable);
            return primaryKeysCurrentTable.ToArray();
        }

        //Получение названия таблиц БД в двусвязном списку
        public LinkedList<string> GetNamesTablesDB()
        {
            UpdateNameTables();
            return GetNameTables();
        }

        //SELECT * FROM sys.database_principals where (type='S' or type = 'U')

        //Получение таблицы пользователей через двусвязный список, элементы которого объекты UsersDatabaseRow
        public LinkedList<UsersRow> GetUsersTable()
        {
            LinkedList<UsersRow> usersNames = new LinkedList<UsersRow>();
            DataRowCollection dataRowCollection = GetRowsInRequest("SELECT name, principal_id, type, type_desc, default_schema_name, create_date, modify_date, authentication_type_desc FROM sys.database_principals WHERE (type='S' or type = 'U');").Rows;
            foreach (DataRow row in dataRowCollection)
            {
                string rowFifth = "";
                if (row[4] != DBNull.Value)
                    rowFifth = row[4].ToString();

                usersNames.AddLast(new UsersRow((string)row[0] ?? "", (int)row[1], (string)row[2] ?? "",
                    (string)row[3] ?? "", rowFifth, (DateTime)row[5], (DateTime)row[6], (string)row[7] ?? ""));
            }

            return usersNames;
        }

        //Создание соединения с нашей БД
        public bool MakeConnectDb(string login, string password)
        {
            if (!IsLegalQuery(login) || !IsLegalQuery(password))
            {
                return false;
            }

            currentNameUser = login;//DESKTOP-0U9RJHC\MSSQLSERVERNEW
            /////МЕНЯТЬ БД ДЛЯ НОВОГО СОЕДИНЕНИЯ
            nameDatabase = "DB_Maria"; 
            connectionString = $"Server=.\\SQLEXPRESS; AttachDbFilename=D:\\SQL\\MSSQL13.SQLEXPRESS\\MSSQL\\DATA\\DB_Maria.mdf; Database='{nameDatabase}'; Trusted_Connection=Yes; User ID='{login}'; Password='{password}'; ";
            /////
            ///


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    UpdateNameTables();
                }
                catch (Exception e)
                {
                    
                    connectionString = @"Error";
                    myConsole.ErrorMessage($"Error! Connection failed, {e.Message}, {e.Data}");
                    return connected = false;
                }

                return connected = true;
            }
        }

        

        //Получение строк таблицы по названию таблицы, совершаем запрос нашей БД
        public LinkedList<List<string>> GetRowsTable(string nameTable)
        {
            LinkedList<List<string>> rowsTableLinkList = new LinkedList<List<string>>();

            LinkedList<UsersRow> usersNames = new LinkedList<UsersRow>();
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

        //Получаем результат в виде таблицы, в зависимости от запроса
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
                        myConsole.ErrorMessage($"Error GetRowsInRequest({request}), {e.Message}");
                    }
                }
            }
            catch (Exception e)
            {
                myConsole.ErrorMessage($"Error GetRowsInRequest({request}), {e.Message}");
            }
            return dataTable;
        }

        //он должен быть приватный и не он должен использоваться TODO пофиксить это
        //Обновляем данные в нашей таблице, совершаем запрос нашей БД
        public void UpdateDataTable(string nameTable, string columnName, string newValue, string namePrimaryId, string primaryId)
        {
            if (!IsLegalQuery(nameTable) || !IsLegalQuery(columnName) || !IsLegalQuery(newValue) || !IsLegalQuery(namePrimaryId) || !IsLegalQuery(primaryId))
            {
                return;
            }
            MakeRequest($"UPDATE [{nameTable}] SET [{columnName}] = '{newValue}' WHERE [{namePrimaryId}] = {primaryId};");
        }

        //Удаляем данные в нашей таблице, совершаем запрос нашей БД
        public void DeleteDataTable(string nameTable, string namePrimaryId, string primaryId)
        {
            if (!IsLegalQuery(nameTable) || !IsLegalQuery(namePrimaryId) || !IsLegalQuery(primaryId))
            {
                return;
            }
            MakeRequest($"DELETE FROM [{nameTable}] WHERE [{namePrimaryId}] = {primaryId};");
        }

        //Создание нового логина пользователя, совершаем запрос к нашей БД
        public bool MakeNewLoginToUser(string name, string password, string role)
        {
            if (!IsLegalQuery(name) || !IsLegalQuery(password) || !IsLegalQuery(role))
            {
                return false;
            }
            MakeRequest($"EXEC sp_addlogin '{name}', '{password}', '{nameDatabase}';");
            MakeRequest($"EXEC sp_adduser '{name}';");
            MakeRequest($"EXEC sp_addrolemember '{role}', '{name}';");

            return true;
        }

        //Создание запроса к нашей БД
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
                        myConsole.ErrorMessage($"Error makeRequest({request}), {e.Message}");
                    }
                }
            }
            catch (Exception e)
            {
                myConsole.ErrorMessage($"Error makeRequest({request}), {e.Message}");
            }
        }

        //Функция, работает, и лучше не комментить, TODO Переделать
        //Добавляем данные в нашу таблицу, совершаем запрос нашей БД
        public void InsertDataTable(string nameTable)
        {
            if (!IsLegalQuery(nameTable))
            {
                return;
            }
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
                            insertValues += $"{(int)obj},";
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
                            myConsole.ErrorMessage(@"Error такого тип не поддерживается, InsertDataTable(string nameTable)");
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
                            insertValues += $"{1},";
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
                            myConsole.ErrorMessage(@"Error такой тип не поддерживается, InsertDataTable(string nameTable)");
                            break;
                    }
                }
                ++i;
            }
            if(insertValues.Count() > 0)
                insertValues = insertValues.Remove(insertValues.Count() - 1, 1);
            MakeRequest($"INSERT INTO [{nameTable}] VALUES({insertValues});");
        }


       
    }
}
