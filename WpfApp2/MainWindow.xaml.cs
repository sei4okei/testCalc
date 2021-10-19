using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string actionMethod, num;
        private float arg1, arg2;

        private void FuncButtons(object sender, RoutedEventArgs e)
        {
            arg1 = TryArgs(arg1);
            actionMethod = sender.ToString();
            textInput.Text = "";
        }

        private void NumButtons(object sender, RoutedEventArgs e)
        {
            num = CatchNameButton(sender.ToString());
            textInput.Text += num;
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            arg2 = TryArgs(arg2);
            switch (CatchNameButton(actionMethod))
            {
                case "+":
                    textHistory.Text = $"{arg1} + {arg2} = {arg1 += arg2}";
                    textInput.Text = arg1.ToString();
                    break;

                case "-":
                    textHistory.Text = $"{arg1} - {arg2} = {arg1 -= arg2}";
                    textInput.Text = arg1.ToString();
                    break;

                case "*":
                    textHistory.Text = $"{arg1} * {arg2} = {arg1 *= arg2}";
                    textInput.Text = arg1.ToString();
                    break;

                case ":":
                    textHistory.Text = $"{arg1} : {arg2} = {arg1 /= arg2}";
                    textInput.Text = arg1.ToString();
                    break;
            }
            arg2 = 0; actionMethod = "";
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            textInput.Text = ""; textHistory.Text = "";
            arg1 = 0; arg2 = 0; actionMethod = "";
        }

        private string CatchNameButton(string ActionMethod)
        {
            if (ActionMethod != null && ActionMethod != "")
            {
                return ActionMethod.Substring(ActionMethod.Length - 1);
            }
            else return "";
        }
        private float TryArgs(float argN)
        {
            try
            {
                if (textInput.Text != null)
                {
                    return float.Parse(textInput.Text);
                }
                else return argN;

            }
            catch (Exception)
            {
                textHistory.Text = "Введите число";
                return argN;
            }
        }
    }
}
