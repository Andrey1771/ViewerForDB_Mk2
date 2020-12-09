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
        const bool StipidRev = true;// you

        public MyConsole(ref TextBox aoutputTextBox)
        {
            SetConsoleOutput(ref aoutputTextBox);
        }

        public ref TextBox GetOutputTextBox()
        {
            return ref outputTextBox;
        }

        public void SetConsoleOutput(ref TextBox aoutputTextBox)
        {
            outputTextBox = aoutputTextBox;
        }

        public void NewMessage(string message)
        {
            Console.WriteLine(message);
            outputTextBox.Text = "";
            outputTextBox.Text += (message + Environment.NewLine);
        }

        public void NewErrorMessage(string message)
        {
            Console.Error.WriteLine(message);
            outputTextBox.Text = "";
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

                regex = new Regex("переполнению");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    outputTextBox.Text += ("Значение было переполнено");
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
