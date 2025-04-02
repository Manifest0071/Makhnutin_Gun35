
using Classes;

namespace Classes
{

    public class Unit
    {
        public string Name { get; }
        private float Health;
        public Interval Damage { get; }
        public float Armor { get; }


        public Unit(string name, float health, float armor, int minDamage, int maxDamage)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Damage = new Interval(minDamage, maxDamage);
        }


        public Unit() : this("Unknown Unit", 100, 0.6f, 0, 10) { }

        public float GetRealHealth()
        {
            return Health * (1f + Armor);
        }

        public bool SetDamage(float value)
        {
            Health -= value * (1f - Armor);
            return Health <= 0f;
        }
    }
    public class Room
    {
        public Unit Unit { get; }
        public Weapon Weapon { get; }

        public Room(Unit unit, Weapon weapon)
        {
            Unit = unit;
            Weapon = weapon;
        }
    }
    public class Dungeon
    {
        private Room[] rooms;

        public Dungeon()
        {
            Random random = new Random();
            int roomCount = random.Next(3, 6);
            rooms = new Room[roomCount];

            for (int i = 0; i < roomCount; i++)
            {
                Unit unit = new Unit($"Боец {i + 1}", random.Next(50, 101), (float)random.NextDouble(), 0, 10);
                Weapon weapon = new Weapon($"Оружие {i + 1}", random.Next(1, 10), random.Next(10, 20));
                rooms[i] = new Room(unit, weapon);
            }
        }

        public void ShowRooms()
        {
            foreach (var room in rooms)
            {
                Console.WriteLine($"Юнит: {room.Unit.Name}, Броня: {room.Unit.Armor}, Урон: {room.Unit.Damage.Min}-{room.Unit.Damage.Max}");
                Console.WriteLine($"Оружие: {room.Weapon.Name}, Урон: {room.Weapon.Damage.Min}-{room.Weapon.Damage.Max}");
                Console.WriteLine("—");
            }
        }
    }
}






