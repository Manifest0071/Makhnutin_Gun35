
namespace Classes
{

    public class Unit
    {
        
            public string Name { get; }
            private float Health;
            public int Damage { get; } = 5;
            public float Armor { get; }

            public Unit(string name, float health, float armor)
            {
                Name = name;
                Health = health;
                Armor = armor;
            }

            public Unit() : this("Unknown Unit", 100, 0.6f) { }

            public float GetRealHealth()
            {
                return Health * (1f + Armor);
            }

            public bool SetDamage(float value)
            {
                Health -= value * Armor;
                return Health <= 0f;
            }
        }
    }

            
    


