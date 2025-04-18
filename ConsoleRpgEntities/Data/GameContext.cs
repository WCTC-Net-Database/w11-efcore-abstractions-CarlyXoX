using ConsoleRpgEntities.Models.Abilities;
using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Characters.Monsters;
using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Abilities.Weapons;
using ConsoleRpgEntities.Models.Abilities.Armor;
using Microsoft.EntityFrameworkCore;

namespace ConsoleRpgEntities.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Ability> Abilities { get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure TPH for Character hierarchy
            modelBuilder.Entity<Monster>()
                .HasDiscriminator<string>(m=> m.MonsterType)
                .HasValue<Goblin>("Goblin");

            // Configure TPH for Ability hierarchy
            modelBuilder.Entity<Ability>()
                .HasDiscriminator<string>(pa=>pa.AbilityType)
                .HasValue<ShoveAbility>("ShoveAbility");

            //Weapons
            modelBuilder.Entity<Weapons>()
                .HasDiscriminator<int>(pa=>pa.BonusDmg)
                .HasValue<ShoveWeaponse>("ShoveWeapons");

            //Armor
            modelBuilder.Entity<Armor>()
                .HasDiscriminator<int>(pa=>pa.BonusHP)
                .HasValue<ShoveArmor>("ShoveArmor");

            // Configure many-to-many relationship
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Abilities)
                .HasMany(w => p.Weapons)
                .HasMany(m => p.Armor)
                .WithMany(a => a.Players)
                .UsingEntity(j => j.ToTable("PlayerAbilities"));

            base.OnModelCreating(modelBuilder);
        }

    }
}


