using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab7_Bd.Messager
{
    public class Messager
    {
        TextBox outputTextBox;
        const bool StipidRev = true;// you

        
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
            if (StipidRev)// Выводим ошибки в пользоавтельском формате
            {
                bool ok = true;
                string s = message;
                Regex regex = new Regex("Запрещено разрешение");
                MatchCollection matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    ok = false;
                    outputTextBox.Text += ("Нет прав на редактирование");
                }

                regex = new Regex("Не удается вставить повторяющийся ключ в объект");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    ok = false;
                    outputTextBox.Text += ("Данный ID уже занят");
                }

                regex = new Regex("Ошибка преобразования");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    ok = false;
                    outputTextBox.Text += ("Ожидалось значение в верном формате");
                }

                regex = new Regex("переполнению");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    ok = false;
                    outputTextBox.Text += ("Значение было переполнено");
                }

                regex = new Regex("Конфликт инструкции");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    ok = false;
                    outputTextBox.Text += ("Действие невозможно из-за конфликтов с другими таблицами");
                }

                regex = new Regex("Не удалось выполнить вход");
                matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    ok = false;
                    outputTextBox.Text += ("Неверные данные входа");
                }

                if(ok)
                    outputTextBox.Text += ("Неизвестная ошибка");
            }
            else
            {
                outputTextBox.Text += (message);
            }

            outputTextBox.Text += Environment.NewLine;
        }

        public Messager(ref TextBox aoutputTextBox)
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

    }
}
