using System.Text;
namespace FuckingCalculator.App;

public class ExpressionEvaluator
{
    public double Evaluate(string input)
    {
        return EvaluateRpn(ToRpn(Tokenize(input)));
    }
    List<string> Tokenize(string input)
    {
        var tokens = new List<string>();
        var number = new StringBuilder();

        foreach (var character in input)
        {
            if (char.IsWhiteSpace(character))
            {
                continue;
            }

            if (char.IsDigit(character))
            {
                number.Append(character);
            }
            else
            {
                if (number.Length > 0)
                {
                    tokens.Add(number.ToString());
                    number.Clear();
                }

                if ("+-*/^()".Contains(character))
                {
                    tokens.Add(character.ToString());
                }
            }
        }

        if (number.Length > 0)
        {
            tokens.Add(number.ToString());
        }

        return tokens;
    }

    List<string> ToRpn(List<string> tokens)
    {
        var output = new List<string>();
        var operators = new Stack<string>();

        var precedence = new Dictionary<string, int>
        {
            ["+"] = 1,
            ["-"] = 1,
            ["*"] = 2,
            ["/"] = 2,
            ["^"] = 3
        };

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out _))
            {
                output.Add(token);
            }
            else if ("+-*/^".Contains(token))
            {
                while (
                    operators.Count > 0 && operators.Peek() != "(" &&
                    precedence[operators.Peek()] >= precedence[token])
                {
                    output.Add(operators.Pop());
                }

                operators.Push(token);
            }
            else if (token == "(")
            {
                operators.Push(token);
            }
            else if (token == ")")
            {
                while (operators.Count > 0 && operators.Peek() != "(")
                {
                    output.Add(operators.Pop());
                }

                if (operators.Count > 0 && operators.Peek() == "(")
                {
                    operators.Pop();
                }
            }
        }

        while (operators.Count > 0)
        {
            output.Add(operators.Pop());
        }

        return output;
    }

    double EvaluateRpn(List<string> rpn)
    {
        var stack = new Stack<double>();

        foreach (var token in rpn)
        {
            if (double.TryParse(token, out double number))
            {
                stack.Push(number);
            }
            else
            {
                double b = stack.Pop();
                double a = stack.Pop();

                double result = token switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b,
                    "^" => Math.Pow(a, b),
                    _ => throw new InvalidOperationException($"An unknown operator is used: {token}")
                };

                stack.Push(result);
            }
        }

        return stack.Pop();
    }
}