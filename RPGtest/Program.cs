using RPGtest;

string heroName = "";
Console.WriteLine("Welcome to the RPG game!");
Thread.Sleep(1000);
while (heroName == "")
{
    Console.WriteLine("What is your name?");
    heroName = Console.ReadLine();
}

HeroClass hero = new HeroClass(heroName);
EnemyClass enemy = new EnemyClass();
int enemiesCreated = 1;
int turnCount = 0;

Console.WriteLine($"Hello {hero.Name}! Please help us fight our enemies! You have {hero.Health} health points. Fight well!");

Thread.Sleep(2000);

//while (hero.Health > 0 && enemy.Health > 0)
while (hero.Health > 0)
{
    if (hero.GetEnemiesDefeated() > 0 && hero.GetEnemiesDefeated() == enemiesCreated)
    {
        Console.WriteLine("New Enemy!");
        enemy = new EnemyClass();
        enemiesCreated++;
    }

    if (turnCount == 0)
    {
        Console.WriteLine($"Your Enemy is a {enemy.TypeOfEnemy}! They have {enemy.Health} health points.");
    }
    else
    {
        Console.WriteLine($"{enemy.TypeOfEnemy} health points: {enemy.Health}. \n {hero.Name}'s health points: {hero.Health}.");
    }
    
    Console.WriteLine("****************************************************************************");

    Thread.Sleep(1000);

    Console.WriteLine("Do you want to attack (enter \"a\"), or heal? (enter \"h\")");
    string decision = Console.ReadLine().ToLower();

    if(decision == "a")
    {
        if (!enemy.BlockAttack())
        {
            hero.Attack(hero, enemy);
            Thread.Sleep(2000);
        }
    }
    else if (decision == "h")
    {
        hero.Heal();
    }

    if (enemy.Health > 0)
    {
        enemy.Attack(hero, enemy);
    }
    else
    {
        hero.SetEnemiesDefeated();
    }
    turnCount++;
}

Console.WriteLine($"Thank you Brave {hero.Name}! You defeated {hero.GetEnemiesDefeated()} enemies!");




