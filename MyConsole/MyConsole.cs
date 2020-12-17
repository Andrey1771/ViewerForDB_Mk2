using System;
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
        const bool StipidRev = true;

        //Конструктор
        public MyConsole(ref TextBox aoutputTextBox)
        {
            SetConsoleOutput(ref aoutputTextBox);
        }

        //Получение ссылки на используемый элемент для вывода данных в строку
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
                Regex regex = new Regex("Запрещено разрешение");
                MatchCollection matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    outputTextBox.Text += ("Нет прав на редактирование");
                }

                regex = new Regex("Не удается вставить повторяющийся ключ в объект");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    outputTextBox.Text += ("Данный ID уже занят");
                }

                regex = new Regex("Ошибка преобразования");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    outputTextBox.Text += ("Ожидалось значение в верном формате");
                }

                regex = new Regex("Конфликт инструкции");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    outputTextBox.Text += ("Действие невозможно из-за конфликтов с другими таблицами");
                }
            }
            else
            {
                outputTextBox.Text += (message);
            }

            outputTextBox.Text += Environment.NewLine;
        }
    }
}
