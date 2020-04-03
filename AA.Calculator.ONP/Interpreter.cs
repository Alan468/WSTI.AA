using AA.Calculator.ONP.BaseTokens;
using AA.Calculator.ONP.Enums;
using AA.Calculator.ONP.Tokens;
using AA.Calculator.ONP.Tokens.Brackets;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AA.Calculator.ONP
{
    public class Interpreter
    {
        const string InvalidMessage = "Invalid input";

        public decimal Calculate(string input)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (input == string.Empty)
                throw new ArgumentException(InvalidMessage);
            string expression = FormatExpression(input);
            TokenFactory tf = new TokenFactory();
            Queue<Token> postfix = GetPostFix(expression, tf);
            return ProcessPostfix(postfix);
        }

        Queue<Token> GetPostFix(string input, TokenFactory tokenFactory)
        {
            Queue<Token> output = new Queue<Token>();
            Stack<Token> stack = new Stack<Token>();
            int position = 0;
            while (position < input.Length)
            {
                Token token = GetNextToken(ref position, input, tokenFactory);
                if (token == null)
                    break;
                if (token is NumberBase)
                    output.Enqueue(token);
                else if (token is FunctionBase)
                    stack.Push(token);
                else if (token is LeftBracket)
                    stack.Push(token);
                else if (token is RightBracket)
                {
                    while (true)
                    {
                        Token taken = stack.Pop();
                        if (!(taken is LeftBracket))
                            output.Enqueue(taken);
                        else
                        {
                            break;
                        }
                    }
                }
                else if (token is OperatorBase)
                {
                    if (stack.Count > 0)
                    {
                        Token top = stack.Peek();
                        bool nested = true;
                        while (nested)
                        {
                            if (top == null || !(top is OperatorBase))
                                break;
                            OperatorBase o1 = (OperatorBase)token;
                            OperatorBase o2 = (OperatorBase)top;
                            if (o1.Associativity == Associativity.Left && (o2.Precedence >= o1.Precedence))
                                output.Enqueue(stack.Pop());
                            else if (o2.Associativity == Associativity.Right && (o2.Precedence > o1.Precedence))
                                output.Enqueue(stack.Pop());
                            else
                                nested = false;
                            top = (stack.Count > 0) ? stack.Peek() : null;
                        }
                    }
                    stack.Push(token);
                }
            }
            while (stack.Count > 0)
            {
                Token next = stack.Pop();
                if (next is LeftBracket || next is RightBracket)
                {
                    throw new ArgumentException(InvalidMessage);
                }
                output.Enqueue(next);
            }
            return output;
        }

        decimal ProcessPostfix(Queue<Token> postfix)
        {
            Stack<Token> stack = new Stack<Token>();
            Token token = null;
            while (postfix.Count > 0)
            {
                token = postfix.Dequeue();
                if (token is NumberBase)
                    stack.Push(token);
                else if (token is OperatorBase)
                {
                    NumberBase right = (NumberBase)stack.Pop();
                    NumberBase left = (NumberBase)stack.Pop();
                    decimal value = ((OperatorBase)token).Calculate(left.Value, right.Value);
                    stack.Push(new Number(value));
                }
                else if (token is FunctionBase)
                {
                    NumberBase arg = (NumberBase)stack.Pop();
                    decimal value = ((FunctionBase)token).Calculate(arg.Value);
                    stack.Push(new Number(value));
                }
            }
            decimal toret = ((NumberBase)stack.Pop()).Value;
            if (stack.Count != 0)
                throw new ArgumentException(InvalidMessage);
            return toret;
        }

        Token GetNextToken(ref int position, string input, TokenFactory tokenFactory)
        {
            Token toret = null;
            Type found = null;
            string rest = input.Substring(position);
            int count = 0;
            int pos = 0;
            while (count++ < rest.Length)
            {
                string cand = rest.Substring(0, count);
                Token latest = tokenFactory.GetToken(cand);
                if (latest != null)
                {
                    //if(found!=null && latest.GetType()!=found)
                    //break;
                    found = latest.GetType();
                    toret = latest;
                    pos = count;
                }
                else
                {
                    //break;
                }
            }
            if (toret != null)
                position += pos;
            return toret;
        }

        string FormatExpression(string input)
        {
            string toret = input;
            toret = toret.Replace(" ", string.Empty);
            string separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            toret = toret.Replace(".", separator);
            toret = toret.Replace(",", separator);
            toret = Regex.Replace(toret, @"^\-", @"0-");
            toret = Regex.Replace(toret, @"\(\-", @"(0-");
            return toret;
        }
    }
}
