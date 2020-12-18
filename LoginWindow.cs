using System;
using System.Windows.Forms;

namespace Lab7
{
    public partial class LoginWindow : Form
    {
        private Database.Db db;
        public LoginWindow(ref Database.Db adb)// лучше решить сигналами
        {
            InitializeComponent();
            db = adb;
        }

        
        //Вызывающая функция при получении сигнала при нажатии на кнопку регистрации, совершаем запрос нашей БД
        private void registrationButton_Click(object sender, EventArgs e)
        {
            db.MakeNewLoginToUser(loginTextBox.Text, passwordTextBox.Text, "");
        }

        //Вызывающая функция при получении сигнала при нажатии на кнопку входа, совершаем запрос нашей БД
        private void loginButton_Click(object sender, EventArgs e)
        {
            db.MakeConnectDb(loginTextBox.Text, passwordTextBox.Text);
            Close();
        }

    }
}
