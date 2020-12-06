using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7_Bd_Mk2_Entity.MyConsole
{
    public class MyConsole
    {
        TextBox outputTextBox;

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
            outputTextBox.Text += (message + Environment.NewLine);
        }
    }
}
