using RPGtest;
using Spectre.Console;

AnsiConsole.MarkupLine("[bold Cyan]Welcome to my RPG game!![/]");
Thread.Sleep(1000);
string heroName = AnsiConsole.Ask<string>("What's your [green]name[/]?");
while (heroName == "")
{
    Console.WriteLine("What is your name?");
    heroName = AnsiConsole.Ask<string>("What's your [green]name[/]???");
}

HeroClass hero = new HeroClass(heroName);
EnemyClass enemy = new EnemyClass();
int enemiesCreated = 1;
int turnCount = 0;

AnsiConsole.MarkupLine($"Hello [bold DarkGreen]{hero.Name}[/]! Please help us fight our enemies! You have [bold Green]{hero.Health}[/] [Green]health points[/]. Fight well!");

Thread.Sleep(2000);

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
        AnsiConsole.MarkupLine($"Your [Red]Enemy[/] is a [bold Red]{enemy.TypeOfEnemy}[/]! They have [bold DarkRed]{enemy.Health}[/] [bold DarkRed]health points[/].");
    }
    else
    {
        AnsiConsole.MarkupLine($"[bold Red]{enemy.TypeOfEnemy}[/] health points: [bold Red]{enemy.Health}[/].\n[bold DarkGreen]{hero.Name}[/]'s health points: [bold DarkGreen]{hero.Health}[/].");
    }

    AnsiConsole.MarkupLine("[bold Cyan]****************************************************************************[/]");

    Thread.Sleep(1000);

    string decision = AnsiConsole.Ask<string>("Do you want to attack (enter \"a\"), or heal? (enter \"h\")").ToLower();
    while (decision != "a" && decision != "h")
    {
        decision = AnsiConsole.Ask<string>("Do you want to attack (enter \"a\"), or heal? (enter \"h\")").ToLower();
    }

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




