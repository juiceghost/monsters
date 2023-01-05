﻿namespace file_io;
class Program
{
    static void Main(string[] args)
    {
        string input = "";
        try { 
            input = File.ReadAllText(@"monsters.txt");
            
        }
        catch
        {
            Console.WriteLine("No file found...");
        }
        //Console.WriteLine(input);
        //Console.ReadLine();
        // pre-defined monsters
        
        string[] monsterNames = new string[0];
        int[] monsterHealthPoints = new int[0];
        int[] monsterAttackPoints = new int[0];
        int[] monsterDefencePoints = new int[0];
        string[][] monsterSkillNames = new string[0][]; // Jagged
        int[][] monsterSkillPoints = new int[0][]; // Jagged

        // TODO: investigate jagged array

        //monsterNames[0] = "Krille";
        //monsterHealthPoints[0] = 10;
        //monsterAttackPoints[0] = 12;
        //monsterDefencePoints[0] = 14;


        string parseAmount(int amountToBeParsed)
        {
            // returnerar en sträng som ser ut t.ex 400.50

            string amountAsString = amountToBeParsed.ToString();
            if (amountAsString.Length > 2)
            {
                string dollars = amountAsString.Substring(0, amountAsString.Length - 2);
                string cents = amountAsString.Substring(amountAsString.Length - 2);
                return dollars + '.' + cents;
            } else
            {
     
                string cents = amountAsString.Substring(amountAsString.Length - 2);
                return "0." + cents;
            }
            
        }
        void inputMoney()
        {
            // Hur hantera input av pengar?
            // "Konton ska kunna ha både kronor och ören"
            bool keepLooping = true;
            
            int amount = 0; // Detta är beloppet multiplicerat med 100, vid visning kom ihåg att dividera med 100
            while (keepLooping)
            {
                Console.WriteLine("Please enter an amount of money");
                Console.Write("===> ");
                string userInput = Console.ReadLine();
                // Har användaren fyllt i ett tal?
                // Om ja, så är det i kronor
                // Har användaren fyllt i en sträng innehållandes en punkt?
                // Om ja, så är värdet till vänster on punkten kronor och till höger om punkten ören

                // 2000 (= 2000 kronor)

                // 300.50 (= 300 kronor, och 50 öre) lagras som 30050

                // 600.400 (= ogiltig inmatning, för många tecken till höger om punkten)


                // hur kolla om det finns en punkt?
                int decimalPointIndex = userInput.IndexOf('.'); // will be -1 if there is no '.', otherwise will be the index of the '.'
                
                string dollars;
                if (decimalPointIndex == -1)
                {
                    // användaren angav inga ören
                    Console.WriteLine($"User entered amount without cents {userInput}");
                    bool isValid = int.TryParse(userInput, out amount);

                    if (isValid)
                    {
                        amount = amount * 100;
                        keepLooping = false;
                        
                    } else
                    {
                        Console.WriteLine("Please enter an amount either in whole dollars or with cents");
                        Console.WriteLine("Example: 100 or 100.54");
                        continue;
                    }
                } else { 
                    Console.WriteLine($"User entered amount with cents {userInput}");
                    // användaren angav ören
                    // parsa inputen till två integers, kronor och ören

                    dollars = (decimalPointIndex > 0) ? userInput.Substring(0, decimalPointIndex) : "0";
                    /*
                    if (decimalPointIndex > 0)
                    {
                         dollars = userInput.Substring(0, decimalPointIndex);
                    } else
                    {
                    
                         dollars = "0";
                    }
                    */
                    string cents = userInput.Substring(decimalPointIndex + 1);
                    if (cents.Length > 2)
                    {
                        Console.WriteLine("Please input maximum 99 cents");
                        continue;
                    }
                    if (cents.Length == 1)
                    {
                        cents = cents + "0";
                    }
                    if (cents.Length == 0)
                    {
                        Console.WriteLine("Invalid input, please try again.");
                        continue;
                    }
                    //Console.WriteLine($"Amount: {dollars} dollars and {cents} cents");
                    amount = int.Parse(dollars) * 100 + int.Parse(cents);
                    keepLooping = false;

                }
                Console.WriteLine($"Raw amount value {amount}");
                Console.WriteLine($"\nUser entered {parseAmount(amount)}");
            }
            

        }
        void extendMonsterArrays()
        {
            // öka antalet element i alla monster-arrayr med ett
            int numberOfMonsters = monsterNames.Length;
            string[] tempMonsterNames = new string[numberOfMonsters + 1];
            int[] tempMonsterHealthPoints = new int[numberOfMonsters + 1];
            int[] tempMonsterAttackPoints = new int[numberOfMonsters + 1];
            int[] tempMonsterDefencePoints = new int[numberOfMonsters + 1];
            string[][] tempMonsterSkillNames = new string[numberOfMonsters + 1][];
            int[][] tempMonsterSkillPoints = new int[numberOfMonsters + 1][];

            for (int l = 0; l < numberOfMonsters; l++)
            {
                tempMonsterNames[l] = monsterNames[l];
                tempMonsterHealthPoints[l] = monsterHealthPoints[l];
                tempMonsterAttackPoints[l] = monsterAttackPoints[l];
                tempMonsterDefencePoints[l] = monsterDefencePoints[l];
                tempMonsterSkillNames[l] = monsterSkillNames[l];
                tempMonsterSkillPoints[l] = monsterSkillPoints[l];
            }
            monsterNames = tempMonsterNames;
            monsterHealthPoints = tempMonsterHealthPoints;
            monsterAttackPoints = tempMonsterAttackPoints;
            monsterDefencePoints = tempMonsterDefencePoints;
            monsterSkillNames = tempMonsterSkillNames;
            monsterSkillPoints = tempMonsterSkillPoints;
        }

        //monsterNames[1] = "Franke";
        //monsterHealthPoints[1] = 18;
        //monsterAttackPoints[1] = 14;
        //monsterDefencePoints[1] = 10;

        // Läs in filen
        // plocka ut en rad i taget
        void parseRow(string monsterRow, int index)
        {
            //Console.WriteLine($"Parsing {monsterRow}");
            var cols = monsterRow.Split(',');
            for (int k = 0; k < cols.Length; k++)
            {
                //Console.WriteLine("Inner foreach loop  {0} col: {1}", k, cols[k]);
                switch (k)
                {
                    case 0:
                        // Name
                        monsterNames[index] = cols[k];
                        break;
                    case 1:
                        // Health
                        monsterHealthPoints[index] = int.Parse(cols[k]);
                        break;
                    case 2:
                        // Attack
                        monsterAttackPoints[index] = int.Parse(cols[k]);
                        break;
                    case 3:
                        // Defence
                        monsterDefencePoints[index] = int.Parse(cols[k]);
                        break;

                }
            }
            // Add some skills to monsterSkills[index]
            string[] tempSkill = new string[] { "Run", "Dodge" };
            int[] tempPoint = new int[] { 10, 30 };
            monsterSkillNames[index] = tempSkill;
            monsterSkillPoints[index] = tempPoint;
        }

        var rows = input.Split('\n');
        Console.WriteLine("Outer For loop:");
        for (int j = 0; j < rows.Length; j++)
        {
            //Console.WriteLine("Outer loop {0}: {1}", j, rows[j]);
            extendMonsterArrays();
            parseRow(rows[j], j);

        }
        
        Console.WriteLine("Menu system");
        bool mainMenu = true;
        while (mainMenu)
        {
            Console.WriteLine("Welcome to Monsters Inc. There are {0} monsters in the database.", monsterNames.Length);
            Console.WriteLine("Please select one of the following");
            Console.WriteLine("1. List all monsters");
            Console.WriteLine("2. Create new monster");
            Console.WriteLine("3. Input money");
            Console.WriteLine("E. Exit");
            Console.Write("----> ");
            string? choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Listing all monsters");
                    for (int i = 0; i < monsterNames.Length; i++)
                    {
                        Console.WriteLine("{0}: HP: {1}, AP: {2}, DP: {3}", monsterNames[i], monsterHealthPoints[i], monsterAttackPoints[i], monsterDefencePoints[i]);
                        for (int j = 0; j < monsterSkillNames[i].Length; j++)
                        {
                            Console.WriteLine("  {0} {1}", monsterSkillNames[i][j], monsterSkillPoints[i][j]);
                        }
                        
                    }
                    Console.WriteLine();
                    break;
                case "2":
                    Console.WriteLine("Creating new monster");
                    // Create
                    // fråga om namn
                    // fråoga om HP, AP, DP
                    // skapa monstret
                    string newMonster = "Tobbe,20,10,12";
                    extendMonsterArrays();
                    parseRow(newMonster, monsterNames.Length - 1);
                    // saveMonsters();

                    Console.WriteLine("Monster successfully added to database");
                    break;
                case "3":

                    inputMoney();
                    break;
                case "E":
                    Console.WriteLine("E selected");
                    Console.WriteLine();
                    mainMenu = false;
                    break;
                default:
                    Console.WriteLine("Please type either 1 or E and press enter");
                    Console.WriteLine();
                    break;

            }
        }
    }
}
