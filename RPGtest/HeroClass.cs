using System;
namespace RPGtest
{
    public class HeroClass : CharacterClass
    {
        //private string name;
        public string Name { get; set; }
        private int EnemiesDefeated { get; set; } = 0;

        public HeroClass(string name)
        {
            Name = name;
            TypeOfCharacter = "Hero";
        }

        public int SuperAttack()
        {
            Console.WriteLine("It's a SUPER ATTACK!!!!");
            return 20;
        }

        public void Heal()
        {
            if (Health == 25)
            {
                Console.WriteLine("You already have full health");
            }
            else
            {
                int healPoints = new Random().Next(5, 15);
                Console.WriteLine($"You healed by {healPoints} points.");
                Health += healPoints;
                Thread.Sleep(2000);
            }
        }

        public bool Dodge()
        {
            int dodgeChance = new Random().Next(1, 11);
            return dodgeChance > 7 ? true : false;
        }

        public void SetHealth(int hitPoints)
        {
            Health -= hitPoints;
        }

        public int GetEnemiesDefeated()
        {
            return EnemiesDefeated;
        }

        public void SetEnemiesDefeated()
        {
            EnemiesDefeated++;
        }
    }
}

