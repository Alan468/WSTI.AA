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
			TestIt("0+0", 0.0m);
			TestIt("0-1+1", 0.0m);
			TestIt("2+3", 5.0m);
			TestIt("0-1", -1.0m);
			TestIt("5*4", 20.0m);
			TestIt("2*3+1", 7.0m);
			TestIt("1*0+1", 1.0m);
			TestIt("2+3+2+2", 9.0m);
			TestIt("0-1+2-3*2", -5.0m);
			TestIt("2^0", 1.0m);
			TestIt("2^8", 256.0m);
			TestIt("2+3*4^2", 50.0m);
			TestIt("6/2", 3m);
			TestIt("5/2", 2.5m);
			TestIt("10/2+1", 6.0m);
			TestIt("10/2*2", 10.0m);
			TestIt("12/6-12", -10.0m);
		}

		[Test]
		public void BracketingTest()
		{
			TestIt("(1-1)", 0.0m);
			TestIt("1+(2-5)", -2.0m);
			TestIt("(2+3)*10", 50.0m);
			TestIt("(2+3)/(10-5)", 1.0m);
			TestIt("((1+1)/(10-9))+5", 7.0m);
			TestIt("((((2*3)+4)-9)*100)-97", 3.0m);
		}

		[Test]
		public void FormatTest()
		{
			TestIt("1+[2-2]", 1.0m);
			TestIt("1+[2-2}", 1.0m);
			TestIt("1+[2-2)", 1.0m);
			TestIt("1 + [  2 - 2 ) ", 1.0m);
			TestIt("1 +[2- 2 ) ", 1.0m);
			TestIt("1,2*2", 2.4m);
			TestIt("1.2*2", 2.4m);
		}

		[Test]
		public void MinusHandleTest()
		{
			TestIt("0-1", -1.0m);
			TestIt("-1+1", 0.0m);
			TestIt("-1-1", -2.0m);
			TestIt("1+(-2)", -1.0m);
			TestIt("(-1)*2", -2.0m);
			TestIt("(-2)^4", 16.0m);
			TestIt("-(-2)+1", 3.0m);
		}

		[Test]
		public void FloatNumbersTest()
		{
			TestIt("3,5*2", 7.0m);
			TestIt("0,01*100", 1.0m);
			TestIt("0.500*2,0", 1.0m);
			TestIt("0,1*0,1", 0.01m);
		}

		[Test]
		public void FunctionsTest()
		{
			TestIt("2!", 2m);
			TestIt("3!", 6m);
			TestIt("4!", 24m);
			TestIt("(4!)+(3!)", 30m);
			TestIt("sin(pi/2)", 1m);
			TestIt("abs(1)", 1m);
			TestIt("abs(-1)", 1m);
			TestIt("abs -1", 1m);
			TestIt("abs (2*3 - 10)", 4m);
			TestIt("sqrt(1)", 1m);
			TestIt("sqrt(9,0)", 3.0m);
			TestIt("sqrt(5*(2+3))", 5.0m);
			TestIt("sqrt(sqrt(81))", 3.0m);
			TestIt("sqrt(sqrt(81))", 3.0m);
			TestIt("round(2,1)", 2.0m);
			TestIt("ceil(2,1)", 3.0m);
			TestIt("floor(2,1)", 2.0m);

			IsBetween("ln(e^4.14)", 4.13m, 4.15m);
			IsBetween("log(e^4.14)", 4.13m, 4.15m);
			IsBetween("log10(100)", 1.99m, 2.01m);
		}

		[Test]
		public void NumbersTest()
		{
			IsBetween("pi+1", 4.13m, 4.15m);
			IsBetween("π+1", 4.13m, 4.15m);
			IsBetween("e*1", 2.717m, 2.719m);
		}

		void TestIt(string input, decimal value)
		{
			Interpreter I = new Interpreter();
			Assert.AreEqual(value, I.Calculate(input));
		}

		void IsBetween(string input, decimal lo, decimal hi)
		{
			Interpreter I = new Interpreter();
			decimal result = I.Calculate(input);
			Assert.IsTrue(result > lo);
			Assert.IsTrue(result < hi);
		}
	}
}