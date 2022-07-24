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

        public void Speak()
        {
            Console.WriteLine($"Prepare for battle!");
        }
    }
}

