using System.Text;
// Задание 1: объединение строк
string ConcatenateStrings(string str1, string str2)
{
    return str1 + str2;
}
Console.WriteLine(ConcatenateStrings("Hello, ", "world!")); // Пример: Hello, world!

// Задание 2: Приветствие пользователя
string GreetUser(string name, int age)
{
    return $"Hello, {name}!\nYou are {age} years old.";
}
Console.Write("Enter your name: ");
string userName = Console.ReadLine();

Console.Write("Enter your age: ");
int userAge;
while (!int.TryParse(Console.ReadLine(), out userAge))
{
    Console.Write("Неправильный возраст, введите его корректно: ");
}
Console.WriteLine(GreetUser(userName, userAge));

// Задание 3: Информация о строке
string GetStringInfo(string input)
{
    return $"Длина строки: {input.Length}\nВерхний регистр: {input.ToUpper()}\nНижний регистр: {input.ToLower()}";
}
string GetFirstFiveCharacters(string input)
{
    return input.Length < 5 ? input : input.Substring(0, 5);
}

Console.Write("Введите строку: ");
string userInput = Console.ReadLine();
Console.WriteLine(GetStringInfo(userInput));

// Задание 4: вывод 5 первых символов из 3 задания
Console.WriteLine($"\nПервые 5 символов: {GetFirstFiveCharacters(userInput)}");

// Задание 5: Объединение массива строк в предложение
StringBuilder JoinStringsWithSpaces(string[] inputArray)
{
    StringBuilder builder = new StringBuilder();
    foreach (string word in inputArray)
    {
        builder.Append(word).Append(' ');
    }

    return builder;
}
Console.WriteLine("Введите слова через пробел:");
string input = Console.ReadLine();
string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
StringBuilder result = JoinStringsWithSpaces(words);
Console.WriteLine("Результат:");
Console.WriteLine(result.ToString().Trim());

// Задание 6: Замена слов в строке

string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
{
    return inputString.Replace(wordToReplace, replacementWord);
}
Console.Write("Введите строку: ");
string inputString = Console.ReadLine();
Console.Write("Введите слово, которое нужно заменить: ");
string wordToReplace = Console.ReadLine();
Console.Write("Введите слово, на которое нужно заменить: ");
string replacementWord = Console.ReadLine();
string resultString = ReplaceWords(inputString, wordToReplace, replacementWord);
Console.WriteLine("Результат замены:");
Console.WriteLine(resultString);