Console.WriteLine("Enter numbers and operations symbol &, |, ^");

if (!Int32.TryParse(Console.ReadLine(), out var a))
{
    Console.WriteLine("Not a number");
    return;
}

if (!Int32.TryParse(Console.ReadLine(), out var b))
{
    Console.WriteLine("Not a number");
    return;
}

string s = Console.ReadLine();
var boolVar = true;

if (s.Length == 0 || s.Length >= 1 && !boolVar)
{
    Console.WriteLine("Not a sign");
    return;
}

switch (s[0])
{
    case '&':
        var result1 = a & b;
        Console.WriteLine("Your number at DEC system " + Convert.ToString(result1,10));
        Console.WriteLine("Your number at BIN system " + Convert.ToString(result1, 2));
        Console.WriteLine("Your number at HEX system " + Convert.ToString(result1, 16));
        break;
    case '|':
        var result2 = a | b;
        Console.WriteLine("Your number at DEC system " + Convert.ToString(result2, 10));
        Console.WriteLine("Your number at BIN system " + Convert.ToString(result2, 2));
        Console.WriteLine("Your number at HEX system " + Convert.ToString(result2, 16));
        break;
    case '^':
        var result3 = a ^ b;
        Console.WriteLine("Your number at DEC system " + Convert.ToString(result3, 10));
        Console.WriteLine("Your number at BIN system " + Convert.ToString(result3, 2));
        Console.WriteLine("Your number at HEX system " + Convert.ToString(result3, 16));
        break;
    default:
        Console.WriteLine("Wrong sign");
        break;
       
        //Переключение на обычный калькулятор ниже
        //switch (s[0])
        //{
        //    case '+':
        //        Console.WriteLine("Result of {0} + {1} = {2}", a, b, a + b);
        //        break;
        //    case '-':
        //        Console.WriteLine("Result of {0} - {1} = {2}", a, b, a - b);
        //        break;
        //    case '*':
        //        Console.WriteLine("Result of {0} * {1} = {2}", a, b, a * b);
        //        break;
        //    case '/':
        //        Console.WriteLine("Result of {0} / {1} = {2}", a, b, a / b);
        //        break;
        //    case '%':
        //        Console.WriteLine("Result of {0} % {1} = {2}", a, b, a % b);
        //        break;
        //    default:
        //        Console.WriteLine("Wrong sign");
        //        break;
}
//var a = 0b100101111;
//Console.WriteLine(Convert.ToString(a), 10);





