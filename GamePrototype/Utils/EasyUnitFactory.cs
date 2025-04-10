using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public class EasyUnitFactory : IUnitFactory
    {
        public Unit CreatePlayer(string name)
        {
            var player = new Player(name, 40, 40, 5);
            player.AddItemToInventory(new Weapon(7, 10, "Rusty Sword"));
            player.AddItemToInventory(new Armour(5, 10, "Cloth Armour"));
            player.AddItemToInventory(new HealthPotion("Small Potion"));
            return player;
        }

        public Unit CreateGoblinEnemy() => new Goblin("Goblin", 10, 10, 2);
    }
}
