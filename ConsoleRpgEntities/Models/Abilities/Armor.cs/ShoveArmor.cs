using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Abilities.Armor
{
    public class ShoveArmor : Armor
    {
        public int Name { get; set; }
        public int BonusHP { get; set; }

        public override void Activate(IPlayer user, ITargetable target)
        {
            // Fireball ability logic
            Console.WriteLine($"{user.Name} equips the {Armor.Name}, gaining +{Armor.BonusHP}.");
        }
    }
}
