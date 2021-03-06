﻿using System;
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
    public partial class LoginForm : Form
    {
        private Database.Database db;
        public LoginForm(ref Database.Database adb)// лучше решить сигналами
        {
            InitializeComponent();
            db = adb;
        }

        //Вызывающая функция при получении сигнала при нажатии на кнопку входа, совершаем запрос нашей БД
        private void loginButton_Click(object sender, EventArgs e)
        {
            db.MakeConnectDb(loginTextBox.Text, passwordTextBox.Text);
            Close();
        }

        //Вызывающая функция при получении сигнала при нажатии на кнопку регистрации, совершаем запрос нашей БД
        private void registrationButton_Click(object sender, EventArgs e)
        {
            db.MakeNewLoginToUser(loginTextBox.Text, passwordTextBox.Text, roleTextBox.Text);
        }
    }
}
