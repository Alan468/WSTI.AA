using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace AA.Calculator.ONP.Test
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}
		
		[Test]
		public void CalculateSimpleTest()
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

		[Test]
		public void BracketingTest()
		{
			TestIt("(1-1)", 0.0);
			TestIt("1+(2-5)", -2.0);
			TestIt("(2+3)*10", 50.0);
			TestIt("(2+3)/(10-5)", 1.0);
			TestIt("((1+1)/(10-9))+5", 7.0);
			TestIt("((((2*3)+4)-9)*100)-97", 3.0);
		}

		[Test]
		public void FormatTest()
		{
			TestIt("1+[2-2]", 1.0);
			TestIt("1+[2-2}", 1.0);
			TestIt("1+[2-2)", 1.0);
			TestIt("1 + [  2 - 2 ) ", 1.0);
			TestIt("1 +[2- 2 ) ", 1.0);
			TestIt("1,2*2", 2.4);
			TestIt("1.2*2", 2.4);
		}

		[Test]
		public void MinusHandleTest()
		{
			TestIt("0-1", -1.0);
			TestIt("-1+1", 0.0);
			TestIt("-1-1", -2.0);
			TestIt("1+(-2)", -1.0);
			TestIt("(-1)*2", -2.0);
			TestIt("(-2)^4", 16.0);
			TestIt("-(-2)+1", 3.0);
		}

		[Test]
		public void FloatNumbersTest()
		{
			var diff = 0.0000001d;
			TestIt("3,5*2", 7.0);
			TestIt("0,01*100", 1.0);
			TestIt("0.500*2,0", 1.0);
			TestIt("0,1*0,1", 0.01d);
			//IsBetween("0,1*0,1", 0.01d- diff, 0.01d+ diff);
		}

		[Test]
		public void FunctionsTest()
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

		[Test]
		public void NumbersTest()
		{
			IsBetween("pi+1", 4.13, 4.15);
			IsBetween("π+1", 4.13, 4.15);
			IsBetween("e*1", 2.717, 2.719);
		}

		void TestIt(string input, double value)
		{
			Interpreter I = new Interpreter();
			Assert.AreEqual(value, I.Calculate(input));
		}

		void IsBetween(string input, double lo, double hi)
		{
			Interpreter I = new Interpreter();
			double result = I.Calculate(input);
			Assert.IsTrue(result > lo);
			Assert.IsTrue(result < hi);
		}
	}
}