using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Abilities
{
    public abstract class Weapon : IAbility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BonusDmg { get; set; }

        public virtual IEnumerable<Player> Players { get; set; }

        protected Weapon()
        {
            Players = new List<Player>();
        }

        public abstract void Activate(IPlayer user, ITargetable target);
    }
}
