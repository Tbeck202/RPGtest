# RPGtest
<strong>A simple textbased console RPG to practice and demonstrate OOP fundamentals</strong>.

The User plays as the Hero of the game. They will be prompted to enter their name and will then be presented with an enemy. 
The Hero and Enemy take turns attacking each other until one of them dies. 
If the Hero dies first, the game is over.
If the Enemy dies first, another Enemy is spawned and the process repeats.
At the end of the game, the User is presented with the number of Enemies they defeated.

## Project Goals
My goal for this simple application is to practice the four pillars of Object Oriented programming: Abstraction, Inheritance, Polymorphism, Encapsulation.

### Inheritance
At the moment, the application has three classes.

First, is `CharacterClass`. This is the base class for both the Hero and the Enemies. Each character [will have a starting `Health` property equal to 25](https://github.com/Tbeck202/RPGtest/new/master?readme=1#character-constructor).

They will also have an [`Attack()`](https://github.com/Tbeck202/RPGtest/new/master?readme=1#attack) method, which is used to decrement the opposing characters `Health`.

Next, we have `HeroClass` which <strong>inherits</strong> `Health` and `Attack()` from `CharacterClass`. 
The Hero class then has it's own [public `Name` property](), as well as a private `EnemiesDefeated` property.
The Hero class also has some [methods](https://github.com/Tbeck202/RPGtest/new/master?readme=1#hero-methods) of it's own. `SuperAttack`, `Heal()`, `Dodge()`, `SetHealth()`, `GetEnemiesDefeated()`, `SetEnemiesDefeated()`

### Abstraction
The [`Attack()`](https://github.com/Tbeck202/RPGtest/new/master?readme=1#attack) method is probably the best example of abstraction in this application. There's a whole lot going on in that method (probably <em>too</em> much... more on that later) but when we call it in `Program.cs`, we don't care what's going on behind the scenes. We just need to know that it will deal damage to the opposing character.

### Encapsulation
There are a few examples of encapsulation in this application, but here's an easy example. The `Hero` class has a method called [`SetEnemiesDefeated()`](https://github.com/Tbeck202/RPGtest/edit/master/README.md#enemies-defeated-encapsulation). Each time the hero defeats an enemy, a private property in the `Hero` class called [`EnemiesDefeated`](https://github.com/Tbeck202/RPGtest/edit/master/README.md#enemies-defeated-encapsulation) is incremented by one. We don't want to interact with the actual property in the class and instead, we use this method as our way of interacting with the property. This same propert has a [`GetEnemiesDefeated()`](https://github.com/Tbeck202/RPGtest/edit/master/README.md#enemies-defeated-encapsulation) defeated as well, which reads and returns the value of `EnemiesDefeated`.

### Polymorphism
I don't yet have a great example of polymorphism in my application, but I have plans to implement a few things that willl demonstrate this principle. First, the [`Attack()`](https://github.com/Tbeck202/RPGtest/new/master?readme=1#attack) method. I would like to refactor this method and define it seperately in the `Hero` and `Enemy` classes. It will remain defined in the `Character` class, just in case I decide to add more characters to the game (like maybe a Wizard that randomly heals the Hero) but will also be redefined with custom functionality specific to the type of character in the `Hero` and `Enemy` classes. Also, I'm planning to implement `Items` into the application. This would allow me to create new weapon types, healing potions, etc. I would create an item interface called `IItem` or something similar in order to ensure that each item had a `Description` property and a `Describe()` method in order to print the item description to the console.

## Things I'd like to improve.
There are a number of improvements that I plan to make to this application. First and foremost, the refactors and additions mentioned in the Polymorphism section. Adding new items and characters will not only help solidify my OOP knowlegde, but will also help make the game more fun. It's a win win! Furthermore, I don't like how many `Console.WriteLine()`'s I have sprinkled around in `Program.cs`. I'd like to <em>at least</em> move these statements into the classes that they are relevant to, but will most likely create a `Message` class that will contain all the relevant messages for the game. I'm sure I'll find more ways to improve as I continue to refactor the game.

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

### Enemies Defeated Encapsulation
```c#
private int EnemiesDefeated { get; set; } = 0;

public int GetEnemiesDefeated()
{
    return EnemiesDefeated;
}

public void SetEnemiesDefeated()
{
    EnemiesDefeated++;
}
 ```
