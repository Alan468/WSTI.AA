using AA.Calculator.ONP;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AA.Calculator.App
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public Interpreter InterpreterOnp { get; set; }
		public bool ActiveComma { get; set; }
		public int ActiveBrackets { get; set; }
		public string LastSing { get; set; }
		public string LastNumber { get; set; }
		public bool UseLast { get; set; }

		public MainWindow()
		{
			InitializeComponent();

			InterpreterOnp = new Interpreter();
			Equation.Text = "";
			Input.Text = "";
			ActiveComma = false;
			ActiveBrackets = 0;
			LastSing = "";
			LastNumber = "";
			UseLast = false;
		}

		private void CommaClick(object sender, RoutedEventArgs e)
		{
			if (ActiveComma)
				return;
			Equation.Text += GetButtonContent(sender);
			ActiveComma = true;
		}

		private void BracketSignClick(object sender, RoutedEventArgs e)
		{
			var content = GetButtonContent(sender);

			if (ActiveComma)
			{
				Equation.Text += "0";
			}

			if (content == "(")
			{
				ActiveBrackets++;
				Equation.Text += content;
			}
			else if (ActiveBrackets > 0 && content == ")")
			{
				ActiveBrackets--;
				Equation.Text += content;
			}

			ActiveComma = false;
		}

		private void FunctionClick(object sender, RoutedEventArgs e)
		{
			if (ActiveComma)
			{
				Equation.Text += "0";
			}
			Equation.Text += GetButtonContent(sender);
			Equation.Text += "(";
			ActiveBrackets++;

			ActiveComma = false;
		}

		private void NumberClick(object sender, RoutedEventArgs e)
		{
			LastNumber = GetButtonContent(sender);
			Equation.Text += LastNumber;
			ActiveComma = false;

			if (UseLast)
			{
				Equation.Text = Input.Text;
			}
		}

		private void SignClick(object sender, RoutedEventArgs e)
		{
			if (ActiveComma)
			{
				Equation.Text += "0";
			}

			LastSing = GetButtonContent(sender);

			Equation.Text += LastSing;
			ActiveComma = false;

			if (UseLast)
			{
				LastNumber = Input.Text;
			}
		}

		private void Calculate(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(Equation.Text))
				Equation.Text = "0";

			if (UseLast && LastSing != "" && LastNumber != "")
			{
				var last = Equation.Text?.Last().ToString();
				if (last != null && int.TryParse(last, out _))
					Equation.Text += LastSing;
				Equation.Text += LastNumber;
			}
			else
			{

				UseLast = true;
			}

			for (; ActiveBrackets > 0; ActiveBrackets--)
			{
				Equation.Text += ")";
			}

			try
			{
				Input.Text = decimal.Round(InterpreterOnp.Calculate(Equation.Text), 10, MidpointRounding.AwayFromZero).ToString("");
			}
			catch (Exception)
			{
				Input.Text = "Błąd w równaniu";
			}
		}
		private void RoundFunctionClick(object sender, RoutedEventArgs e)
		{
			Equation.Text = $"round({Input.Text})";
			Calculate(sender, e);
		}
		private void ABSFunctionClick(object sender, RoutedEventArgs e)
		{
			Equation.Text = $"abs({Input.Text})";
			Calculate(sender, e);
		}

		private void ClearEquation(object sender, RoutedEventArgs e)
		{
			Equation.Text = "";
			Input.Text = "";
			LastSing = "";
			LastNumber = "";
			UseLast = false;
			ActiveComma = false;
			ActiveBrackets = 0;
		}

		private string GetButtonContent(object sender)
		{
			var button = sender as Button;
			return (string)button.Content;
		}
	}
}
