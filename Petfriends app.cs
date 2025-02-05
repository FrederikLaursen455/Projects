// Program der simulerer en dyre-fremvisningsapp. Hjælpemidler: Microsoft Learn

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

int maxPets = 8;
string? readResult;
string menuSelection = "";

string[,] ourAnimals = new string[maxPets, 6];  

for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;          
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }
    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

do
{
    Console.Clear();
    Console.WriteLine("Welcome to the Frederik Laursen PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the app");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");
   
    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    switch (menuSelection)
    {
        case "1":
            // Viser alle nuværende dyr
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "2":
            // Tilføjer et nyt dyr til ourAnimals array
            string anotherPet = "y";
            int petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }
            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }
            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validEntry = false;
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                        animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
                        do
                        {
                            int petAge;
                            Console.WriteLine("Enter the pet's age or enter ? if unknown");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalAge = readResult;
                                if (animalAge != "?")
                                {
                                    validEntry = int.TryParse(animalAge, out petAge);
                                }
                                else
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);
                        do
                        {
                            Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPhysicalDescription = readResult.ToLower();
                                if (animalPhysicalDescription == "")
                                {
                                    animalPhysicalDescription = "tbd";
                                }
                            }
                        } while (animalPhysicalDescription == "");
                        do
                        {
                            Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPersonalityDescription = readResult.ToLower();
                                if (animalPersonalityDescription == "")
                                {
                                    animalPersonalityDescription = "tbd";
                                }
                            }
                        } while (animalPersonalityDescription == "");
                        do
                        {
                            Console.WriteLine("Enter a nickname for the pet");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalNickname = readResult.ToLower();
                                if (animalNickname == "")
                                {
                                    animalNickname = "tbd";
                                }
                            }
                        } while (animalNickname == "");
                    }
                    ourAnimals[petCount, 0] = "ID # " + animalID;
                    ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                    ourAnimals[petCount, 2] = "Age: " + animalAge;
                    ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                    ourAnimals[petCount, 4] = "Physical: " + animalPhysicalDescription;
                    ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;
  
                } while (validEntry == false);
                petCount = petCount + 1;
                if (petCount < maxPets)
                {
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }
            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }
            break;
        case "3":
            // Sikrer at alle dyrs aldre og fysiske karakteristika er udfyldt
            int petCount3 = 0;
            string petNoAge;
            int petNoAgeInt;
            bool validEntry2 = false;
            for (int i = 0; i < maxPets; i++)
            {
                petCount3 = petCount3 + 1;
                if (ourAnimals[i, 2] == "Age: ?")
                {
                    petNoAge = ourAnimals[i, 0];
                    do
                    {
                        Console.WriteLine("Enter an age for " + petNoAge);
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            validEntry2 = int.TryParse(readResult, out petNoAgeInt);
                            ourAnimals[petCount3, 2] = "Age: " + petNoAgeInt;
                        }
                    } while (validEntry2 == false);
                    bool validEntry3 = false;
                    string animalPhysicalDescriptionNull;
                    if (validEntry2 == true && animalPhysicalDescription == "")
                        animalPhysicalDescriptionNull = animalPhysicalDescription;
                    do
                    {
                        Console.WriteLine("Enter a physical description for ID #: c4 (size, color, breed, gender, weight, housebroken)");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalPhysicalDescriptionNull = readResult;
                            if (animalPhysicalDescriptionNull != "")
                            {
                                validEntry3 = true;
                                Console.WriteLine("Age and physical Description fields are complete for all of our friends.");
                                ourAnimals[petCount3, 4] = "Physical: " + animalPhysicalDescriptionNull;
                            }
                        }
                    } while (validEntry3 == false);
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "4":
            string newPetNickName = "";
            string petNoNickName = "";
            int petCount4 = 0;
            bool validEntry4 = false;
            bool validEntry5 = false;
            // Sikrer at alle kælenavne og personligheder er udfyldt
            for (int i = 0; i < maxPets; i++)
            {
                petCount4 = petCount4 + 1;
                if (ourAnimals[i, 3] == "Nickname: " && validEntry5 == false)
                {
                    petNoNickName = ourAnimals[i, 0];
                    {
                        do
                        {
                            Console.WriteLine("Enter a nickname for " + petNoNickName);
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                newPetNickName = readResult.ToLower();
                                ourAnimals[petCount4, 3] = "Nickname " + newPetNickName;
                                if (newPetNickName.Length >= 3)
                                {
                                    validEntry4 = true;
                                }
                            }
                        } while (validEntry4 == false);
                        string animalPersonalityDescriptionNull = "";
                        if (validEntry4 == true && newPetNickName == "")
                            animalPersonalityDescriptionNull = animalPersonalityDescription;
                        do
                        {
                            Console.WriteLine("Enter a personality description for ID #: c4 (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                                animalPersonalityDescriptionNull = readResult;
                            if (animalPersonalityDescriptionNull != "")
                            {
                                validEntry5 = true;
                                Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
                                ourAnimals[petCount4, 5] = "Personality: " + animalPersonalityDescriptionNull;
                            }
                        } while (validEntry5 == false);
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "5":
            // Retter et dyrs alder - under opbygning
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "6":
            // Retter et dyrs personlighedstræk - under opbygning
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "7":
            // Viser alle katte med en specific karakteristika - under opbygning
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "8":
            // Viser alle hunde med en specific karakteristika - under opbygning
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        default:
            break;
    }
} while (menuSelection != "exit");