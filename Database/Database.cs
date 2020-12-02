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
        public Database()
        {
            
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
                Console.Error.WriteLine(@"Error \-_-/ Connection failed");
                //throw new Exception("GetFlightRows(), Error");
            }
        }

        public LinkedList<string> GetNamesTablesDB()
        {
            LinkedList<string> tableNames = new LinkedList<string>();

            foreach (DataRow row in GetRowsInRequest("SELECT Name FROM sys.Tables").Rows)
            {
                tableNames.AddLast((string)row[0]);
            }

            return tableNames;
        }

        public bool MakeConnectDb(string login, string password)
        {
            currentNameUser = login;
            connectionString = $"Server=.\\SQLEXPRESS; Data Source=DESKTOP-A2TI617\\SQLEXPRESS; Database=MS_SQL_Lab_2; User ID={login}; Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch(Exception e)
                {
                    connectionString = @"Error \-_-/";
                    Console.Error.WriteLine($"Error \\-_-/ Connection failed , {e.Message}");
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
                catch(Exception e)
                {
                    Console.Error.WriteLine($"Error \\-_-/ makeRequest({request}), {e.Message}");
                }
            }

        }

        private DataTable GetRowsInRequest(string request)
        {
            DataTable dataTable = new DataTable();

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
                catch(Exception e)
                {
                    Console.Error.WriteLine($"Error \\-_-/ GetRowsInRequest({request}), {e.Message}");
                }
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
                    if(GetRowsInRequest(request).Rows[0].Field<int?>(0) != null)
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
        public LinkedList<OwnersAirplanesRow> SelectOwnersAirplanes(string model)
        {
            LinkedList <OwnersAirplanesRow> table = new LinkedList<OwnersAirplanesRow>();

            foreach (DataRow row in GetRowsInRequest($"SELECT * FROM [ВыбратьВладельцевСамолетов]('{model}')").Rows)
            {
                table.AddLast(new OwnersAirplanesRow((string)row[0], (string)row[1]));
            }

            return table;
        }

        public LinkedList<OwnersAirplanesRow> SelectAirplanesAirline(string airline)
        {
            LinkedList<OwnersAirplanesRow> table = new LinkedList<OwnersAirplanesRow>();

            foreach (DataRow row in GetRowsInRequest($"SELECT * FROM [ВыбратьСамолетыАвиакомпании]('{airline}')").Rows)
            {
                table.AddLast(new OwnersAirplanesRow((string)row[0], (string)row[1]));
            }

            return table;
        }

        private DataTable GetRows(string tableName)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                OpenConnection(connection);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = $"SELECT * FROM {tableName};";
                
                dataTable.Load(cmd.ExecuteReader());
            }
            return dataTable;
        }

        public LinkedList<FlightRow> GetFlightRows()
        {
            LinkedList<FlightRow> table = new LinkedList<FlightRow>();
            DataTable dataTable = GetRows("Рейс");

            foreach(DataRow row in dataTable.Rows)
            {
                table.AddLast(new FlightRow((int)row[0], (int)row[1], (int)row[2], (string)row[3],
                    (decimal?)row[4], (DateTime)row[5], (DateTime)row[6]));
            }

            return table;
        }

        public LinkedList<AirlineRow> GetAirlineRows()
        {
            LinkedList<AirlineRow> table = new LinkedList<AirlineRow>();
            DataTable dataTable = GetRows("Авиакомпания");

            foreach (DataRow row in dataTable.Rows)
            {
                table.AddLast(new AirlineRow((int)row[0], (string)row[1], (string)row[2], (DateTime)row[3],
                    (int?)row[4]));
            }

            return table;
        }

        public LinkedList<OwnerRow> GetOwnerRows()
        {
            LinkedList<OwnerRow> table = new LinkedList<OwnerRow>();
            DataTable dataTable = GetRows("Владелец");

            foreach (DataRow row in dataTable.Rows)
            {
                table.AddLast(new OwnerRow((int)row[0], (string)row[1], (int?)row[2], (int?)row[3],
                    (string)row[4]));
            }

            return table;
        }

        public LinkedList<AirplaneRow> GetAirplaneRows()
        {
            LinkedList<AirplaneRow> table = new LinkedList<AirplaneRow>();
            DataTable dataTable = GetRows("Самолет");

            foreach (DataRow row in dataTable.Rows)
            {
                table.AddLast(new AirplaneRow((int)row[0], (int)row[1], (string)row[2], (string)row[3],
                    (DateTime)row[4], (decimal?)row[5]));
            }

            return table;
        }

    }
}
