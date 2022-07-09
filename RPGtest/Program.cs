using RPGtest;

string heroName = "";
Console.WriteLine("Welcome to the RPG game!");
while(heroName == "")
{
    Console.WriteLine("What is your name?");
    heroName = Console.ReadLine();
}

HeroClass hero = new HeroClass(heroName);
EnemyClass enemy = new EnemyClass();

Console.WriteLine($"Hello {hero.Name}! Please help us fight our enemies! You have {hero.Health} health points. Fight well!");

while(hero.Health > 0 && enemy.Health > 0)
{
    int enemyCount = 0;
    Console.WriteLine($"Your Enemy is a {enemy.TypeOfEnemy}! They have {enemy.Health} health points.");
    Console.WriteLine("****************************************************************************");
    enemyCount++;
    Thread.Sleep(1000);
    Console.WriteLine("Do you want to attack (enter \"a\"), or heal? (enter \"h\")");
    string decision = Console.ReadLine();
    if(decision == "a")
    {
        Console.WriteLine($"{hero.Name} Attacks!");
        Thread.Sleep(2000);
        if (enemy.BlockAttack() != 0)
        {
            Console.WriteLine("Oh no! The enemy blocked your attack!");
            Thread.Sleep(2000);
            continue;
        }
        hero.Attack(enemy);
        Thread.Sleep(2000);
    }
    else if (decision == "h")
    {
        if (hero.Health == 25)
        {
            Console.WriteLine("You already have full health");
            continue;
        }
        hero.Health += hero.Heal();
        Thread.Sleep(2000);
    }
    enemy.Attack(hero);
}

Console.WriteLine("Thanks for playing!");




