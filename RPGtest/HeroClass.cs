using System;
namespace RPGtest
{
    public class HeroClass : CharacterClass
    {
        //private string name;
        public string Name { get; set; }

        public HeroClass(string name)
        {
            Name = name;
            TypeOfCharacter = "Hero";
        }
    }
}

