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
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public string equation;
		public string Equation
		{
			get => equation; 
			set
			{
				equation = value;
				OnPropertyChanged("Equation");
			}
		}
		public string input;
		public string Input {
			get => input;
			set
			{
				input = value;
				OnPropertyChanged("Input");
			}
		}

		public Interpreter InterpreterOnp { get; set; }

		public MainWindow()
		{
			InterpreterOnp = new Interpreter();
			Equation = "";
			Input = "";
			InitializeComponent();
		}

		private void FunctionClick(object sender, RoutedEventArgs e)
		{

		}

		private void NumberClick(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			Input += button.Content;
		}

		private void SignClick(object sender, RoutedEventArgs e)
		{
			Equation += Input;
			var button = sender as Button;
			ClearCurrentValue(sender, e);
			Equation += button.Content;
		}

		private void Calculate(object sender, RoutedEventArgs e)
		{
			Equation += Input;
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

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
