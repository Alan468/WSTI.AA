using AA.Calculator.ONP.BaseTokens;
using AA.Calculator.ONP.Tokens;
using AA.Calculator.ONP.Tokens.Basic;
using AA.Calculator.ONP.Tokens.Brackets;
using AA.Calculator.ONP.Tokens.Functions;
using AA.Calculator.ONP.Tokens.Numbers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace AA.Calculator.ONP
{
    public class TokenFactory
    {
        Dictionary<Func<string, bool>, Type> RegisteredTokens;

        public TokenFactory()
        {
            RegisteredTokens = new Dictionary<Func<string, bool>, Type>();
            string separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string reqexSeparator = Regex.Escape(separator);

            //basic operators
            RegisterToken<Addition>(x => x == "+");
            RegisterToken<Subtraction>(x => x == "-");
            RegisterToken<Multiplication>(x => x == "*");
            RegisterToken<Division>(x => x == "/" || x == @"\");
            RegisterToken<Modulus>(x => x == "%" || x == "MOD");
            RegisterToken<Power>(x => x == "^");

            //Numbers
            RegisterToken<Pi>(x => Match(x, "pi", "π"));
            RegisterToken<E>(x => x == "e");

            RegisterToken<Number>(x => {
                string[] patterns = new string[] {
                    string.Format(@"^(\d+({0}\d*)?)$",reqexSeparator), //dec/float
                    @"^0[xX][0-9a-fA-F]+$" // hex
                };
                return patterns.Any(p => Regex.Match(x, p).Success);
            });

            //brackets
            RegisterToken<LeftBracket>(x => x == "(" || x == "[" || x == "{");
            RegisterToken<RightBracket>(x => x == ")" || x == "]" || x == "}");

            //functions
            RegisterToken<Sinus>(x => Match(x, "sin"));
            RegisterToken<Cosinus>(x => Match(x, "cos"));
            RegisterToken<Tangent>(x => Match(x, "tan", "tg"));
            RegisterToken<ABS>(x => Match(x, "abs"));
            RegisterToken<Sqrt>(x => Match(x, "sqrt"));
            RegisterToken<ArcTangent>(x => Match(x, "atan", "atg"));
            RegisterToken<ArcSinus>(x => Match(x, "asin"));
            RegisterToken<ArcCosinus>(x => Match(x, "acos"));
            RegisterToken<Ceiling>(x => Match(x, "ceil", "ceiling"));
            RegisterToken<Floor>(x => Match(x, "floor"));
            RegisterToken<Factorial>(x => Match(x, "!"));
            RegisterToken<Round>(x => Match(x, "round", "rnd"));
            RegisterToken<Exp>(x => Match(x, "exp"));
            RegisterToken<Logarithm>(x => Match(x, "log", "ln"));
            RegisterToken<Logarithm10>(x => Match(x, "log10"));
        }

        public Token GetToken(string exact)
        {
            Token toret = null;
            foreach (var kvp in RegisteredTokens)
            {
                if (kvp.Key(exact))
                {
                    toret = (Token)Activator.CreateInstance(kvp.Value, exact);
                    break;
                }
            }
            return toret;
        }

        bool Match(string cand, params string[] names)
        {
            foreach (string name in names)
            {
                if (name.Equals(cand, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        void RegisterToken<T>(Func<string, bool> match) where T : Token
        {
            if (RegisteredTokens.ContainsKey(match))
                throw new NotSupportedException("Token for predicate already added");
            RegisteredTokens[match] = typeof(T);
        }


    }
}
