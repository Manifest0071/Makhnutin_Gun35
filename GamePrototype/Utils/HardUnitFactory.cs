using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public class HardUnitFactory : IUnitFactory
    {
        public Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new Weapon(10, 15, "Steel Sword"));
            player.AddItemToInventory(new Armour(10, 15, "Iron Armour"));
            player.AddItemToInventory(new HealthPotion("Potion"));
            return player;
        }

        public Unit CreateGoblinEnemy() => new Goblin("Elite Goblin", 25, 25, 5);
    }
}
