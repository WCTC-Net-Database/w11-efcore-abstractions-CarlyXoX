using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Abilities.Weapons
{
    public class ShoveWeapons : Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public override void Activate(IPlayer user, ITargetable target)
        {
            // Fireball ability logic
            Console.WriteLine($"{user.Name} attacks {target.Name} with a {Weapon.Name}, dealing +{Weapon.BonusDmg} dmg to the enemy.");
        }
    }
}
