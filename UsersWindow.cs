using System;
using System.Windows.Forms;
using Lab7.Database;

namespace Lab7
{
    public partial class UsersWindow : Form
    {
        private Database.Db db;
        private TextBox oldOutputTextBox;

        public UsersWindow(ref Database.Db adb)
        {
            db = adb;
            InitializeComponent();
            oldOutputTextBox = db.GetMyConsole().GetTextBox();
            db.GetMyConsole().SetOutput(ref consoleLogTextBox);
            UpdateUsersView();
        }

        ~UsersWindow()
        {
            db.GetMyConsole().SetOutput(ref oldOutputTextBox);
        }

        //Вызывающая функция при получении сигнала при нажатии на кнопку обновления пользователей, совершаем запрос нашей БД
        private void updateUsersButton_Click(object sender, EventArgs e)
        {
            UpdateUsersView();
        }

        //Обновляем пользователей в нашей таблице, совершаем запрос нашей БД
        public void UpdateUsersView()
        {
            if (db.connected)
            {
                DbUtilities inst = new DbUtilities(ref db.GetMyConsole());
                inst.UpdateUsersView(dataGridView1, db);
            }
        }
    }
}
