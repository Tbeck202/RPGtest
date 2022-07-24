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

        public int Attack(EnemyClass enemy)
        {
            int damage = new Random().Next(1, 10);
            int multiplier = new Random().Next(1, 3);
            int hitPoints = 0;
            
            Console.WriteLine($"{this.Name} Attacks!");
            Thread.Sleep(1000);

            int setAttackType = new Random().Next(1, 100);
                
            if (setAttackType > 80)
            {
                hitPoints = this.SuperAttack();
                //enemy.SetHealth(hitPoints);
            }
            else
            {
                hitPoints = damage * multiplier;
                //enemy.SetHealth(hitPoints);
            }
            Console.WriteLine($"You hit the enemy with {hitPoints} points!");
            //Console.WriteLine($"The {enemy.TypeOfEnemy} now has {enemy.Health} health points.");
            return hitPoints;
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
            Thread.Sleep(1000);
            Health -= hitPoints;
            Console.WriteLine($"{this.Name} now has {this.Health} health points.");
            Thread.Sleep(2000);
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

