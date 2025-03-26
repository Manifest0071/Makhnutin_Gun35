using System.Globalization;

//В соответствии с ТЗ выбран класс 1

namespace Classes
{


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Подготовка к бою");

            Console.Write("Введите имя бойца: ");
            string name = Console.ReadLine();

            float health;
            do
            {
                Console.Write("Введите начальное здоровье бойца (10-100): ");
            } while (!float.TryParse(Console.ReadLine(), out health) || health < 10 || health > 100);

            float helmArmor, shellArmor, bootsArmor;

            do
            {
                Console.Write("Введите значение брони шлема от 0 до 1: ");
            } while (!float.TryParse(Console.ReadLine(), out helmArmor) || helmArmor < 0 || helmArmor > 1);
            Helm helm = new Helm(helmArmor);

            do
            {
                Console.Write("Введите значение брони кирасы от 0 до 1: ");
            } while (!float.TryParse(Console.ReadLine(), out shellArmor) || shellArmor < 0 || shellArmor > 1);
            Shell shell = new Shell(shellArmor);

            do
            {
                Console.Write("Введите значение брони сапог от 0 до 1: ");
            } while (!float.TryParse(Console.ReadLine(), out bootsArmor) || bootsArmor < 0 || bootsArmor > 1);
            Boots boots = new Boots(bootsArmor);

            float totalArmor = helm.Armor + shell.Armor + boots.Armor;
            Unit player = new Unit(name, health, totalArmor);

            Console.WriteLine($"Общий показатель брони равен: {player.Armor}");
            Console.WriteLine($"Фактическое значение здоровья равно: {player.GetRealHealth()}");
        }
    }
}

