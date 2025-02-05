// Simpel RPG game hvor hero og monster skiftes til at skade

int hero = 10;
int monster = 10;

Random dice = new Random();
int roll = dice.Next(1, 11);

do
{
    monster -= roll;
    Console.WriteLine($"Monster was damaged and lost {roll} health and now has {monster} health.");
    roll = dice.Next(1, 11);
    if (monster <= 0) continue;
    hero -= roll;
    Console.WriteLine($"Hero was damaged and lost {roll} health and now has {hero} health.");
    roll = dice.Next(1, 11);
} while (monster > 0 && hero > 0);

Console.WriteLine(hero > monster ? "Hero wins!" : "Monster wins!");