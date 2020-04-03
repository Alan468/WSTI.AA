using AA.Calculator.ONP;
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

namespace AA.Calculator.App
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public string Equation { get; set; }
		public string Input { get; set; }
		public Interpreter InterpreterOnp { get; set; }

		public MainWindow()
		{
			InterpreterOnp = new Interpreter();
			InitializeComponent();
		}

		private void FunctionClick(object sender, RoutedEventArgs e)
		{

		}

		private void NumberClick(object sender, RoutedEventArgs e)
		{

		}

		private void SignClick(object sender, RoutedEventArgs e)
		{

		}

		private void Calculate(object sender, RoutedEventArgs e)
		{
			Input = InterpreterOnp.Calculate(Equation).ToString();
		}

		private void ClearCurrentValue(object sender, RoutedEventArgs e)
		{
			Input = "";
		}

		private void ClearEquation(object sender, RoutedEventArgs e)
		{
			Equation = "";
			ClearCurrentValue(sender, e);
		}
	}
}
