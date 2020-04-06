using AA.Calculator.ONP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace AA.Calculator.App
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public string LastSign { get; set; }
		public string LastNumber { get; set; }
		public bool UseLast { get; set; }
		public string LastResult { get; set; }

		public Interpreter InterpreterOnp { get; set; }

		public MainWindow()
		{
			InitializeComponent();

			InterpreterOnp = new Interpreter();
			Equation.Text = "";
			Input.Text = "";
			LastSign = "";
			LastNumber = "";
			LastResult = "";
			UseLast = false;
		}

		private void FunctionClick(object sender, RoutedEventArgs e)
		{

		}

		private void NumberClick(object sender, RoutedEventArgs e)
		{
			if (UseLast)
			{
				Equation.Text = Input.Text;
			}
			UseLast = false;
			var button = sender as Button;
			Input.Text += button.Content;
			LastNumber = (string)button.Content;
		}

		private void SignClick(object sender, RoutedEventArgs e)
		{
			if (UseLast)
			{
				Equation.Text = Input.Text;
			}
			else
			{
				Equation.Text += Input.Text;
			}
			UseLast = false;
			var button = sender as Button;
			ClearCurrentValue(sender, e);
			Equation.Text += button.Content;
			LastSign = (string)button.Content;
		}

		private void Calculate(object sender, RoutedEventArgs e)
		{
			if (UseLast)
			{
				Equation.Text = Input.Text;
				Equation.Text += LastSign;
				Equation.Text += LastNumber;
			}
			else
			{
				if (string.IsNullOrEmpty(Input.Text) && string.IsNullOrEmpty(LastResult))
				{
					Input.Text = LastNumber;

				}
				else if (string.IsNullOrEmpty(Input.Text) && !string.IsNullOrEmpty(LastResult))
				{
					LastNumber = LastResult;
					Input.Text = LastResult;
				}

				Equation.Text += Input.Text;
			}

			try
			{
				Input.Text = LastResult = InterpreterOnp.Calculate(Equation.Text).ToString();

			}
			catch (Exception ex)
			{
				Input.Text = ex.Message;
			}

			UseLast = true;
		}

		private void ClearCurrentValue(object sender, RoutedEventArgs e)
		{
			Input.Text = "";
		}

		private void ClearEquation(object sender, RoutedEventArgs e)
		{
			Equation.Text = "";
			LastSign = "";
			LastNumber = "";
			LastResult = "";
			ClearCurrentValue(sender, e);
		}
	}
}
