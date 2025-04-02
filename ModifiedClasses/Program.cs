using System.Globalization;

namespace Classes
{
    public struct Interval
    {
        private static readonly Random Random = new Random();

        public float Min { get; }
        public float Max { get; }

        public Interval(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                Console.WriteLine("Некорректные входные данные: minValue > maxValue. Значения поменяны местами.");
                (minValue, maxValue) = (maxValue, minValue);
            }

            if (minValue < 0)
            {
                Console.WriteLine("Некорректные входные данные: minValue < 0. Установлено в 0.");
                minValue = 0;
            }

            if (maxValue < 0)
            {
                Console.WriteLine("Некорректные входные данные: maxValue < 0. Установлено в 10.");
                maxValue = 10;
            }

            if (minValue == maxValue)
            {
                Console.WriteLine("minValue и maxValue равны. maxValue увеличен на 10.");
                maxValue += 10;
            }

            Min = minValue;
            Max = maxValue;
        }

        public float Get()
        {
            return (float)(Random.NextDouble() * (Max - Min) + Min);
        }
    }

    

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Подготовка к бою");

            Console.Write("Введите имя бойца: ");
            string name = Console.ReadLine();

            int health;
            do
            {
                Console.Write("Введите начальное здоровье бойца (10-100): ");
            } while (!int.TryParse(Console.ReadLine(), out health) || health < 10 || health > 100);

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

            Console.Write("Укажите минимальный урон оружия (0-20): ");
            float minDamage = GetValidInput(0, 20);

            Console.Write("Укажите максимальный урон оружия (20-40): ");
            float maxDamage = GetValidInput(20, 40);

            Weapon sword = new Weapon("Меч", (int)minDamage, (int)maxDamage);

            float totalArmor = helm.Armor + shell.Armor + boots.Armor;
            Unit player = new Unit(name, health, totalArmor, 5, 15);

            Console.WriteLine($"Общий показатель брони равен: {player.Armor}");
            Console.WriteLine($"Фактическое значение здоровья равно: {player.GetRealHealth()}");
            Console.WriteLine($"Оружие: {sword.Name}, Мин. урон: {sword.Damage.Min}, Макс. урон: {sword.Damage.Max}, Средний урон: {sword.GetDamage()}");
            Dungeon dungeon = new Dungeon();
            dungeon.ShowRooms();



            static float GetValidInput(float min, float max)
            {
                while (true)
                {
                    if (float.TryParse(Console.ReadLine(), out float value) && value >= min && value <= max)
                    {
                        return value;
                    }
                    Console.Write($"Введите число в диапазоне {min}-{max}: ");
                }
            }
        }
    }
}

