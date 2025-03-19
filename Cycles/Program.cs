namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PrintEvenNumbers();
            PrintFibonacci();
            PrintMultiplicationTable();
            CheckPassword();
        }

        static void PrintEvenNumbers()
        {
            int[] evenNumbers = new int[10];
            for (int i = 0, num = 2; i < evenNumbers.Length; i++, num += 2)
            {
                evenNumbers[i] = num;
            }
            Console.WriteLine("Чётные числа от 2 до 20: " + string.Join(", ", evenNumbers));
        }
        static void PrintFibonacci()
        {
            int[] fibonacci = new int[10];
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            for (int i = 2; i < fibonacci.Length; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }
            Console.WriteLine("Последовательность Фибоначчи: " + string.Join(", ", fibonacci));
        }
        static void PrintMultiplicationTable()
        {
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write($"{i * j}\t");
                }
                Console.WriteLine("Умножение");
            }
        }
        static void CheckPassword()
        {
            string password = "qwerty";
            string userInput;

            do
            {
                Console.Write("Введите пароль: ");
                userInput = Console.ReadLine();

                if (userInput != password)
                {
                    Console.WriteLine("Неверный пароль. Попробуйте снова.");
                }
            }
            while (userInput != password);

            Console.WriteLine("Доступ разрешен.");
        }

    }
}
 


 
