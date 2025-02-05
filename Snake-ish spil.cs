// Snake-agtigt spil hvor man skal samle mad og skifter form efter maden man har spist. Hjælpemidler Microsoft Learn

Random random = new Random();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

// Spillerposition
int playerX = 0;
int playerY = 0;

// Madposition
int foodX = 0;
int foodY = 0;

// Spillerstadier og tilsvarende madtyper
string[] states = { "('-')", "(^-^)", "(X_X)" };
string[] foods = { "@@@@@", "$$$$$", "#####" };

// Nuværende viste spillerstadie
string player = states[0];

// Index af nuværende mad
int food = 0;

bool isHappy = false;
InitializeGame();
while (!shouldExit)
{
    isHappy = HappyCheck();
    if (isHappy)
    {
        Move(3);
    }
    else
    {
        Move();
    }
    if (FoodConsumed())
    {
        ChangePlayer();
        ShowFood();
        if (SadCheck())
        {
            FreezePlayer();
        }
    }
    if (TerminalResized())
    {
        Console.Clear();
        Console.WriteLine("Console was resized. Program exiting.");
        Console.ReadKey();
        shouldExit = true;
    }
}
Console.Clear();

// Hvis man resizer terminalen/vinduet, så lukker spillet
bool TerminalResized()
{
    return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}

// Metode der viser mad på en random plads
void ShowFood()
{
    // Opdaterer maden til en random type ud fra index
    food = random.Next(0, foods.Length);

    // Opdaterer maden til en ny position i terminalen
    foodX = random.Next(0, width - player.Length);
    foodY = random.Next(0, height - 1);

    // Viser maden
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[food]);
}

// Skifter spillerstadiet ud fra maden der er spist
void ChangePlayer()
{
    player = states[food];
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Hvis man spiser #### så dør man og skal vente 2 sekunder
void FreezePlayer()
{
    System.Threading.Thread.Sleep(2000);
    player = states[0];
}

// Håndterer input fra spilleren, med optional speedboost (3) hvis man har spist det rigtige mad
void Move(int MoveSpeed = 1)
{
    int lastX = playerX;
    int lastY = playerY;
    {
        if (MoveSpeed == 3)
        {

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    playerY--;
                    break;
                case ConsoleKey.DownArrow:
                    playerY++;
                    break;
                case ConsoleKey.LeftArrow:
                    playerX -= 3;
                    break;
                case ConsoleKey.RightArrow:
                    playerX += 3;
                    break;
                case ConsoleKey.Escape:
                    shouldExit = true;
                    break;
                default:
                    Console.Clear();
                    shouldExit = true;
                    break;
            }

            // Sørger for at characters fra hvor man var før bliver slettet
            Console.SetCursorPosition(lastX, lastY);
            for (int i = 0; i < player.Length; i++)
            {
                Console.Write(" ");
            }

            // Sørger for at man holder sig inden for rammerne
            playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
            playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

            // Spilleren starter på en ny position
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(player);
        }
        else

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    playerY--;
                    break;
                case ConsoleKey.DownArrow:
                    playerY++;
                    break;
                case ConsoleKey.LeftArrow:
                    playerX--;
                    break;
                case ConsoleKey.RightArrow:
                    playerX++;
                    break;
                case ConsoleKey.Escape:
                    shouldExit = true;
                    break;
                default:
                    Console.Clear();
                    shouldExit = true;
                    break;
            }

        Console.SetCursorPosition(lastX, lastY);
        for (int i = 0; i < player.Length; i++)
        {
            Console.Write(" ");
        }

        playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
        playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

        Console.SetCursorPosition(playerX, playerY);
        Console.Write(player);
    }
}

// Clearer consollen, og viser spiller og mad
void InitializeGame()
{
    Console.Clear();
    ShowFood();
    Console.SetCursorPosition(0, 0);
    Console.Write(player);
}

bool FoodConsumed()
{
    if (foodX == playerX && foodY == playerY)
    {
        return true;
    }
    return false;
}

bool SadCheck()
{
    if (player == states[2])
    {
        return true;
    }
    return false;
}
bool HappyCheck()
{
    if (player == states[1])
    {
        return true;
    }
    return false;
}