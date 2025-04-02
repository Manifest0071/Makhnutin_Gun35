

namespace Classes
{
    public class Weapon
    {
        public string Name { get; }
        public Interval Damage { get; private set; }
        public float Durability { get; } = 1.0f;

        public Weapon(string name, int minDamage, int maxDamage)
        {
            Name = name;
            SetDamageParams(minDamage, maxDamage);
        }

        public void SetDamageParams(int minDamage, int maxDamage)
        {
            if (minDamage > maxDamage)
            {
                Console.WriteLine($"Некорректные данные {Name}. Смена значений урона.");
                (minDamage, maxDamage) = (maxDamage, minDamage);
            }

            if (minDamage < 1)
            {
                Console.WriteLine($"Установка минимального урона в 1 для {Name}.");
                minDamage = 1;
            }

            if (maxDamage <= 1)
            {
                Console.WriteLine($"Установка максимального урона в 10 для {Name}.");
                maxDamage = 10;
            }

            Damage = new Interval(minDamage, maxDamage);
        }

        public int GetDamage()
        {
            return (int)Math.Round(Damage.Get()); ;
        }
        
    }






}
       
    

