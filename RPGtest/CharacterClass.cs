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
        public int Attack(CharacterClass character)
        {
            int damage = new Random().Next(1, 10);
            int multiplier = new Random().Next(1, 3);
            int hitPoints = damage * multiplier;
            if (TypeOfCharacter == "Hero")
            {
                Console.WriteLine($"You hit the enemy with {hitPoints} points!");
                character.Health -= hitPoints;
                Console.WriteLine($"The enemy now has {character.Health} health points.");
            }
            else
            {
                Console.WriteLine($"The enemy attacks! You take {hitPoints} damage.");
                character.Health -= hitPoints;
                Console.WriteLine($"You now have {character.Health} health points.");
                Thread.Sleep(2000);
            }

            return hitPoints;
        }

        public int Heal()
        {
            return new Random().Next(1, 10);
        }

        public void Speak()
        {
            Console.WriteLine($"Prepare for battle!");
        }
    }
}

