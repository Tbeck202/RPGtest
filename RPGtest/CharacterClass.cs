using System;
namespace RPGtest
{
    public class CharacterClass
    {
         //Properties
        public string? TypeOfCharacter { get; set; }
        public int Health { get; set; }

        //Constructor
        public CharacterClass() 
        {
            Health = 25;
        }

        //Methods
        /*
        public int Attack(HeroClass hero, EnemyClass enemy)
        {
            int damage = new Random().Next(1, 10);
            int multiplier = new Random().Next(1, 3);
            int hitPoints = damage * multiplier;
            if (TypeOfCharacter == "Hero")
            {
                Console.WriteLine($"{hero.Name} Attacks!");
                Thread.Sleep(1000);

                int setAttackType = new Random().Next(1, 100);
                
                if (setAttackType > 80)
                {
                    hitPoints = hero.SuperAttack();
                    enemy.SetHealth(hitPoints);
                }
                else
                {
                    enemy.SetHealth(hitPoints);
                }
                Console.WriteLine($"You hit the enemy with {hitPoints} points!");
                Console.WriteLine($"The {enemy.TypeOfEnemy} now has {enemy.Health} health points.");
            }
            else
            {
                if (hero.Dodge())
                {
                    Console.WriteLine($"{hero.Name} dodged the {enemy.TypeOfEnemy}'s attack!");
                }
                else
                {
                    Console.WriteLine($"The {enemy.TypeOfEnemy} attacks! You take {hitPoints} damage.");
                    hero.SetHealth(hitPoints);
                    Thread.Sleep(1000);
                    Console.WriteLine($"You now have {hero.Health} health points.");
                    Thread.Sleep(2000);
                }
            }
            return hitPoints;
        }
        */

        public void Speak()
        {
            Console.WriteLine($"Prepare for battle!");
        }
    }
}

