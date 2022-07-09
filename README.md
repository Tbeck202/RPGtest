# RPGtest
<strong>A simple textbased console RPG to practice and demonstrate OOP fundamentals</strong>.

The User plays as the Hero of the game. They will be prompted to enter their name and will then be presented with an enemy. 
The Hero and the Enemy take turns attacking each other until one of them dies. 
If the Hero dies first, the game is over.
If the Enemy dies first, another Enemy is spawned and the process repeats.
At the end of the game, the User is presented with the number of Enemies they're defeated.

## Project Goals
My goal for this simple application is to practice the four pillars of Object Oriented programming: Abstraction, Inheritance, Polymorphism, Encapsulation.

### Inheritance
The application has three classes.

First, is `CharacterClass`. This is the base class for both the Hero and the Enemies. Each character [will have a starting `Health` property equal to 25](https://github.com/Tbeck202/RPGtest/new/master?readme=1#character-constructor).

They will also have an [`Attack()`](https://github.com/Tbeck202/RPGtest/new/master?readme=1#attack) method, which is used to decrement the opposing characters `Health`.

Next, we have `HeroClass` which <strong>inherits</strong> `Health` and `Attack()` from `CharacterClass`. 
The Hero class then has it's own [public `Name` property](), as well as a private `EnemiesDefeated` property.
The Hero class also has some [methods](https://github.com/Tbeck202/RPGtest/new/master?readme=1#hero-methods) of it's own. `SuperAttack`, `Heal()`, `Dodge()`, `SetHealth()`, `GetEnemiesDefeated()`, `SetEnemiesDefeated()`

## Code Snippets
### Character Constructor
```c#
public int Health { get; set; }

public CharacterClass() 
{
  Health = 25;
}
``` 

### Hero Constructor
```c#
public string Name { get; set; }
private int EnemiesDefeated { get; set; } = 0;

public HeroClass(string name)
{
    Name = name;
    TypeOfCharacter = "Hero";
}
```
### Attack()
```c#
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
```

### Hero Methods
```c#
public void Heal()
{
    if (Health == 25)
    {
        Console.WriteLine("You already have full health");
    }
    else
    {
        int healPoints = new Random().Next(5, 15);
        Console.WriteLine($"You healed by {healPoints} points.");
        Health += healPoints;
        Thread.Sleep(2000);
    }
}

public bool Dodge()
{
    int dodgeChance = new Random().Next(1, 11);
    return dodgeChance > 7 ? true : false;
}

public void SetHealth(int hitPoints)
{
    Health -= hitPoints;
}

public int GetEnemiesDefeated()
{
    return EnemiesDefeated;
}

public void SetEnemiesDefeated()
{
    EnemiesDefeated++;
}
```
