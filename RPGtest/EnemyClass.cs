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

        public bool BlockAttack()
        {
            int blockChance = new Random().Next(1, 100);
            bool successfulBlock = blockChance > 85 ? true : false;
            if (successfulBlock)
            {
                Console.WriteLine($"Oh no! The enemy blocked your attack!");
                Thread.Sleep(2000);
                Health -= new Random().Next(2, 5);
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
        }
    }
}

