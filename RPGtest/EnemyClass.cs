using Spectre.Console;
using System;

namespace RPGtest
{
    public class EnemyClass : CharacterClass
    {
        public string TypeOfEnemy { get; set; }
        public EnemyClass()
        {
            TypeOfCharacter = "Enemy";
            TypeOfEnemy = enemySelector();
        }

        public int Attack(HeroClass hero)
        {
            int damage = new Random().Next(1, 10);
            int multiplier = new Random().Next(1, 3);
            int hitPoints = 0;
           
            if (hero.Dodge())
            {
                Console.WriteLine($"{hero.Name} dodged the {this.TypeOfEnemy}'s attack!");
            }
            else
            {
                hitPoints = damage * multiplier;
                Console.WriteLine($"The {this.TypeOfEnemy} attacks! {hero.Name} takes {hitPoints} damage.");
            }
            
            return hitPoints;
        }

        public bool BlockAttack()
        {
            int blockChance = new Random().Next(1, 100);
            bool successfulBlock = blockChance > 85 ? true : false;
            if (successfulBlock)
            {
                Console.WriteLine($"Oh no! The enemy blocked your attack!");
                Thread.Sleep(2000);
                int hitPoints = new Random().Next(1, 5);
                Console.WriteLine($"But you only hit the {this.TypeOfEnemy} with {hitPoints} hit points.");
                this.Health -= hitPoints;
                return true;
            }
            return false;
        }

        static string enemySelector()
        {
            int enemySelector = new Random().Next(1, 3);
            string enemyType = enemySelector == 1 ? "Beast" : "Demon";
            return enemyType;
        }

        public void SetHealth(int hitPoints)
        {
            Health -= hitPoints;
            if(this.Health > 0)
            {
                Console.WriteLine($"The {this.TypeOfEnemy} now has {this.Health} health points.");
            }
            else
            {
                AnsiConsole.MarkupLine($"You killed the [bold Red]{this.TypeOfEnemy}[/]!");
            }
        }
    }
}

