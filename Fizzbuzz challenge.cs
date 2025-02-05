//klassisk fizzbuzz challenge. Tæller op til 100. Hver gang et tal kan divideres med 3 tilføjer den fizz, buzz hver gang det er 15, og fizzbuzz ved begge instanser

for (int i = 0; i < 100);
{
    i++;
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine($"{i} - FizzBuzz");
    }
    else if (i % 5 == 0)
    {
    Console.WriteLine($"{i} - Buzz");
    }
    else if (i % 3 == 0)    
    {
        Console.WriteLine($"{i} - Fizz");
    }
    else
    {
    Console.WriteLine(i);
    }
}