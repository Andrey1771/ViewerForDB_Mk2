using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab7_Bd_Mk2_Entity.Database;

namespace Lab7_Bd_Mk2_Entity
{
    public partial class ChangeUsersDataForm : Form
    {
        public ChangeUsersDataForm(ref Database.Database db)
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void updateUsersButton_Click(object sender, EventArgs e)
        {
            //SELECT * FROM sys.database_principals where (type='S' or type = 'U')
        }

        /*
        private void UpdateRowsDataGrid1(string tableName)
        {
            currentTableName = tableName;
            clearDataGridView();

            switch (tableName)
            {
                case "Рейс":
                    LinkedList<FlightRow> tablesFlight = db.GetFlightRows();

                    foreach (string name in FlightRow.namesColumn)
                    {
                        DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
                        dataGridViewColumn.HeaderText = name;
                        dataGridViewColumn.Name = name;
                        dataGridView1.Columns.Add(dataGridViewColumn);
                    }
                    foreach (FlightRow row in tablesFlight)
                    {
                        dataGridView1.Rows.Add(row.GetArrayStr());
                    }
                    break;

                case "Владелец":
                    LinkedList<OwnerRow> tablesOwner = db.GetOwnerRows();

                    foreach (string name in OwnerRow.namesColumn)
                    {
                        DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
                        dataGridViewColumn.HeaderText = name;
                        dataGridViewColumn.Name = name;

                        dataGridView1.Columns.Add(dataGridViewColumn);
                    }
                    foreach (OwnerRow row in tablesOwner)
                    {
                        dataGridView1.Rows.Add(row.GetArrayStr());
                    }
                    break;

                case "Авиакомпания":
                    LinkedList<AirlineRow> tablesAirline = db.GetAirlineRows();

                    foreach (string name in AirlineRow.namesColumn)
                    {
                        DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
                        dataGridViewColumn.HeaderText = name;
                        dataGridViewColumn.Name = name;
                        dataGridView1.Columns.Add(dataGridViewColumn);
                    }
                    foreach (AirlineRow row in tablesAirline)
                    {
                        dataGridView1.Rows.Add(row.GetArrayStr());
                    }
                    break;

                case "Самолет":
                    LinkedList<AirplaneRow> tablesAirplane = db.GetAirplaneRows();

                    foreach (string name in AirplaneRow.namesColumn)
                    {
                        DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
                        dataGridViewColumn.HeaderText = name;
                        dataGridViewColumn.Name = name;
                        dataGridView1.Columns.Add(dataGridViewColumn);
                    }
                    foreach (AirplaneRow row in tablesAirplane)
                    {
                        dataGridView1.Rows.Add(row.GetArrayStr());
                    }
                    break;
            }

        }*/
    }
}
