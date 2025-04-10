using GamePrototype.Items.EconomicItems;
using GamePrototype.Utils;
namespace GamePrototype.Dungeon
{
    public enum Direction
    {
        Left = -1, Forward = 0, Right = 1
    }

    public interface IDungeonBuilder
    {
        DungeonRoom BuildDungeon();
    }

    public class EasyDungeonBuilder : IDungeonBuilder
    {
        public DungeonRoom BuildDungeon()
        {
            var start = new DungeonRoom("Start");
            var leftRoom = new DungeonRoom("Left Room", new Gold());
            var rightRoom = new DungeonRoom("Right Room", new Grindstone("Stone"));
            var final = new DungeonRoom("Exit");

            start.TrySetDirection(Direction.Left, leftRoom);
            start.TrySetDirection(Direction.Right, rightRoom);

            leftRoom.TrySetDirection(Direction.Forward, final);
            rightRoom.TrySetDirection(Direction.Forward, final);

            return start;
        }
    }

    public class HardDungeonBuilder : IDungeonBuilder
    {
        public DungeonRoom BuildDungeon()
        {
            var start = new DungeonRoom("Dark Entrance");
            var leftCombat = new DungeonRoom("Trap Room", UnitFactoryDemo.CreateGoblinEnemy());
            var rightCombat = new DungeonRoom("Goblin Nest", UnitFactoryDemo.CreateGoblinEnemy());
            var bossRoom = new DungeonRoom("Final Battle", new Grindstone("End Stone"));

            start.TrySetDirection(Direction.Left, leftCombat);
            start.TrySetDirection(Direction.Right, rightCombat);

            leftCombat.TrySetDirection(Direction.Forward, bossRoom);
            rightCombat.TrySetDirection(Direction.Forward, bossRoom);

            return start;
        }
    }


}

