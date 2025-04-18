using ConsoleRpgEntities.Models.Abilities;
using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Abilities.Weapons;
using ConsoleRpgEntities.Models.Abilities.Armor;
using ConsoleRpgEntities.Models.Attributes;

namespace ConsoleRpgEntities.Models.Characters
{
    public class Player : ITargetable, IPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Experience { get; set; }

        public virtual IEnumerable<Ability> Abilities { get; set; } = new List<Ability>();
        public virtual IEnumerable<Weapon> Weapons { get; set; } = new List<Weapon>();
        public virtual IEnumerable<Armor> Armor { get; set; } = new List<Armor>();

        public void DisplayWeapons()
        {
            foreach (var weapon in Weapons)
            {
                Console.WriteLine($"{weapon.Id} {weapon.Name} {weapon.Description} {weapon.BonusDmg}");
            }
        }

        public void WeaponAttack(ITargetable target)
        {
            Console.WriteLine("Select your weapon:");
            DisplayWeapons();
            if (int.TryParse(Console.ReadLine(), out int weaponSelect))
            {
                var weapon = Weapons.FirstOrDefault(w => w.Id == weaponSelect);
                if (weapon != null)
                {
                    Console.WriteLine($"You use the {weapon.Name} to attack, dealing +{weapon.BonusDmg} bonus damage to {target.Name}.");
                }
                else
                {
                    Console.WriteLine("Invalid weapon selected.");
                }
            }
        }

        public void DisplayArmor()
        {
            foreach (var armor in Armor)
            {
                Console.WriteLine($"{armor.Id} {armor.Name} {armor.Description} {armor.BonusHP}");
            }
        }

        public int CalcNewHP()
        {
            Console.WriteLine("Select your armor:");
            DisplayArmor();
            if (int.TryParse(Console.ReadLine(), out int armorEquip))
            {
                var selectedArmor = Armor.FirstOrDefault(a => a.Id == armorEquip);
                if (selectedArmor != null)
                {
                    int newHP = Health + selectedArmor.BonusHP;
                    Console.WriteLine($"You equip the {selectedArmor.Name}, granting you +{selectedArmor.BonusHP} bonus HP.");
                    Console.WriteLine($"Your new total health is {newHP}.");
                    return newHP;
                }
            }

            Console.WriteLine("Invalid armor selected. Health remains unchanged.");
            return Health;
        }

        public void Attack(ITargetable target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} with a sword!");
        }

        public void UseAbility(IAbility ability, ITargetable target)
        {
            if (Abilities.Contains(ability))
            {
                ability.Activate(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} does not have the ability {ability.Name}!");
            }
        }
    }
}
