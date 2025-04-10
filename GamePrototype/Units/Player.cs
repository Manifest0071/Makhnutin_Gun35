using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon) 
            {
                return BaseDamage + weapon.Damage;
            }
            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                if (items[i] is EconomicItem economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem)
            {
                if (_equipment.ContainsKey(equipItem.Slot))
                {
                    var replaced = _equipment[equipItem.Slot];
                    _equipment[equipItem.Slot] = equipItem;
                    Console.WriteLine($"[EQUIP] {equipItem.Slot} replaced: {replaced.Name} -> {equipItem.Name}");
                }
                else
                {
                    _equipment.Add(equipItem.Slot, equipItem);
                    Console.WriteLine($"[EQUIP] Equipped {equipItem.Name} to slot {equipItem.Slot}");
                }
                return;
            }
            base.AddItemToInventory(item);
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion)
            {
                Health += healthPotion.HealthRestore;
                Console.WriteLine($"[POTION] Restored {healthPotion.HealthRestore} HP. Current: {Health}/{MaxHealth}");
            }
            else if (economicItem is Grindstone)
            {
                if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
                {
                    weapon.Repair(5);
                    Console.WriteLine($"[WHETSTONE] {weapon.Name} repaired. Current durability: {weapon.Durability}");
                }
                Inventory.TryRemove(economicItem); 
            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour)
            {
                damage -= (uint)(damage * (armour.Defence / 100f));
                armour.ReduceDurability(1);
                Console.WriteLine($"[ARMOUR] {armour.Name} durability decreased to {armour.Durability}");
            }
            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
    }
}
