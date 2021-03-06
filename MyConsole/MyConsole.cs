﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab7_Bd_Mk2_Entity.MyConsole
{
    public class MyConsole
    {
        TextBox outputTextBox;
        const bool StipidRev = true;// you

        //Конструктор, вуху
        public MyConsole(ref TextBox aoutputTextBox)
        {
            SetConsoleOutput(ref aoutputTextBox);
        }

        //Получение ссылки на используемый элемент для вывода данных в какую-то строку
        public ref TextBox GetOutputTextBox()
        {
            return ref outputTextBox;
        }

        //Установка выводимого элемента со ссылкой
        public void SetConsoleOutput(ref TextBox aoutputTextBox)
        {
            outputTextBox = aoutputTextBox;
        }

        //Отправка сообщения в элемент класса консоли, а также элемента вывода формы
        public void NewMessage(string message)
        {
            Console.WriteLine(message);
            outputTextBox.Text += (message + Environment.NewLine);
        }

        //Отправка сообщения ошибки в элемент класса консоли, а также элемента вывода формы
        public void NewErrorMessage(string message)
        {
            Console.Error.WriteLine(message);

            if (StipidRev)
            {
                string s = message;
                bool ok = true;
                Regex regex = new Regex("Запрещено разрешение");
                MatchCollection matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    outputTextBox.Text += ("Нет прав на редактирование");
                    ok = false;
                }

                regex = new Regex("Не удается вставить повторяющийся ключ в объект");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    outputTextBox.Text += ("Данный ID уже занят");
                    ok = false;
                }

                regex = new Regex("Ошибка преобразования");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    outputTextBox.Text += ("Ожидалось значение в верном формате");
                    ok = false;
                }

                regex = new Regex("переполнению");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    outputTextBox.Text += ("Значение было переполнено");
                    ok = false;
                }

                regex = new Regex("Конфликт инструкции");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    outputTextBox.Text += ("Действие невозможно из-за конфликтов с другими таблицами");
                    ok = false;
                }

                regex = new Regex("Не удалось выполнить вход");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    outputTextBox.Text += ("Неверные данные входа");
                    ok = false;
                }

                if (ok)
                    outputTextBox.Text += (message);
            }
            else
            {
                outputTextBox.Text += (message);
            }

            outputTextBox.Text += Environment.NewLine;
        }
    }
}
