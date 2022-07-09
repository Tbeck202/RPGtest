using System;
namespace RPGtest
{
    public class EnemyClass : CharacterClass
    {
        public string TypeOfEnemy { get; set; }
        //{
        //    get { return TypeOfEnemy; }
        //    set
        //    {
        //        int enemySelector = new Random().Next(1, 3);
        //        string enemyType = enemySelector == 1 ? "Beast" : "Demon";
        //        TypeOfEnemy = enemyType;
        //    }
        //}
        public EnemyClass()
        {
            TypeOfCharacter = "Enemy";
            TypeOfEnemy = enemySelector();
        }

        public int BlockAttack()
        {
            int blockChance = new Random().Next(1, 100);
            bool successfulBlock = blockChance > 85 ? true : false;
            if(successfulBlock)
            {
                return new Random().Next(2, 5);
            }
            return 0;
        }

        static string enemySelector()
        {
            int enemySelector = new Random().Next(1, 3);
            string enemyType = enemySelector == 1 ? "Beast" : "Demon";
            return enemyType;
        }
    }
}

