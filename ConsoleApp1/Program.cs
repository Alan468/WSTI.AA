using AA.Calculator.ONP;
using System;
using System.Globalization;
using System.Threading;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			//CalculateSimpleTest();
			//BracketingTest();
			//FormatTest();
			//MinusHandleTest();
			FloatNumbersTest();
			//FunctionsTest();
			//NumbersTest();
		}

		public static void FunctionsTest()
		{
			TestIt("sin(pi/2)", 1);
			TestIt("abs(1)", 1);
			TestIt("abs(-1)", 1);
			TestIt("abs (2*3 - 10)", 4);
			TestIt("sqrt(1)", 1);
			TestIt("sqrt(9,0)", 3.0);
			TestIt("sqrt(5*(2+3))", 5.0);
			TestIt("sqrt(sqrt(81))", 3.0);
			TestIt("sqrt(sqrt(81))", 3.0);
			TestIt("round(2,1)", 2.0);
			TestIt("ceil(2,1)", 3.0);
			TestIt("floor(2,1)", 2.0);

			IsBetween("ln(e^4.14)", 4.13, 4.15);
			IsBetween("log(e^4.14)", 4.13, 4.15);
			IsBetween("log10(100)", 1.99, 2.01);
		}

		public static void NumbersTest()
		{
			IsBetween("pi+1", 4.13, 4.15);
			IsBetween("π+1", 4.13, 4.15);
			IsBetween("e*1", 2.717, 2.719);
		}

		public static void Test1()
		{
			var Inp = new Interpreter();
			var result = Inp.Calculate(@"(1+ sin(pi/2) + ln(e^3) - sqrt(9) * log10(10) +0xE) / (20.34323354+floor(2.6))");

			if (0.002 != result)
			{
				throw new Exception();
			}
		}

		public static void CalculateSimpleTest()
		{
			TestIt("0+0", 0.0);
			TestIt("0-1+1", 0.0);
			TestIt("2+3", 5.0);
			TestIt("0-1", -1.0);
			TestIt("5*4", 20.0);
			TestIt("2*3+1", 7.0);
			TestIt("1*0+1", 1.0);
			TestIt("2+3+2+2", 9.0);
			TestIt("0-1+2-3*2", -5.0);
			TestIt("2^0", 1.0);
			TestIt("2^8", 256.0);
			TestIt("2+3*4^2", 50.0);
			TestIt("6/2", 3);
			TestIt("5/2", 2.5);
			TestIt("10/2+1", 6.0);
			TestIt("10/2*2", 10.0);
			TestIt("12/6-12", -10.0);

		}

		public static void BracketingTest()
		{
			TestIt("(1-1)", 0.0);
			TestIt("1+(2-5)", -2.0);
			TestIt("(2+3)*10", 50.0);
			TestIt("(2+3)/(10-5)", 1.0);
			TestIt("((1+1)/(10-9))+5", 7.0);
			TestIt("((((2*3)+4)-9)*100)-97", 3.0);
		}

		public static void FormatTest()
		{
			TestIt("1+[2-2]", 1.0);
			TestIt("1+[2-2}", 1.0);
			TestIt("1+[2-2)", 1.0);
			TestIt("1 + [  2 - 2 ) ", 1.0);
			TestIt("1 +[2- 2 ) ", 1.0);
			TestIt("1,2*2", 2.4);
			TestIt("1.2*2", 2.4);
		}

		public static void MinusHandleTest()
		{
			TestIt("0-1", -1.0);
			TestIt("-1+1", 0.0);
			TestIt("-1-1", -2.0);
			TestIt("1+(-2)", -1.0);
			TestIt("(-1)*2", -2.0);
			TestIt("(-2)^4", 16.0);
			TestIt("-(-2)+1", 3.0);
		}

		public static void FloatNumbersTest()
		{
			TestIt("3,5*2", 7.0);
			TestIt("0,01*100", 1.0);
			TestIt("0.500*2,0", 1.0);
			TestIt("0,1*0,1", 0.01);
		}


		static void TestIt(string input, double value)
		{
			Interpreter I = new Interpreter();

			var a = I.Calculate(input);
			Console.Write($"input= {input}   value= {value}  result={a}  CORRECT={a == value}");
			if (a != value)
			{
				Console.WriteLine($"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
				//throw new Exception();
			}
			else { Console.WriteLine(); return; }
		}

		static void IsBetween(string input, double lo, double hi)
		{
			Interpreter I = new Interpreter();
			double result = I.Calculate(input);
			Console.Write($"input= {input}   value= {lo}-{hi}  result={result}  CORRECT={result > lo && result < hi}");
			if (!(result > lo && result < hi))
			{
				Console.WriteLine($"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
				// throw new Exception();
			}
			else { Console.WriteLine(); return; }

		}
	}
}
