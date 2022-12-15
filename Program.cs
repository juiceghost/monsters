namespace file_io;
class Program
{
    static void Main(string[] args)
    {
        //string input = "";
        //try {
        //    input = File.ReadAllText(@"monsters.txt");

        //}
        //catch
        //{
        //    Console.WriteLine("No file found...");
        //}
        //Console.WriteLine(input);
        //Console.ReadLine();
        // pre-defined monsters

        //Monster[] monsters = new Monster[0];

        Monster[] monsters = new Monster[]
        {
            new Monster{
                Name = "Krille",
                Health = 20,
                Defense = 10,
                Attacks = new Attack[]
                {
                    new Attack
                    {
                        Name = "Omnislash",
                        AttackValue = 30
                    },
                    new Attack
                    {
                        Name = "KOTR",
                        AttackValue = 40
                    },
                    new Attack
                    {
                        Name = "Mimic",
                        AttackValue = 30
                    },
                }
            },
            new Monster{
                Name = "Franke",
                Health = 24,
                Defense = 13,
                Attacks = new Attack[]
                {
                    new Attack
                    {
                        Name = "Mimic",
                        AttackValue = 40
                    },
                    new Attack
                    {
                        Name = "Mime",
                        AttackValue = 20
                    },
                    new Attack
                    {
                        Name = "Run away",
                        AttackValue = 0
                    },
                    new Attack
                    {
                        Name = "Hack",
                        AttackValue = 50
                    },
                }
            }
        };

    Console.WriteLine("hej");
    //string[] monsterNames = new string[0];
    //int[] monsterHealthPoints = new int[0];
    //int[] monsterAttackPoints = new int[0];
    //int[] monsterDefencePoints = new int[0];

    //monsterNames[0] = "Krille";
    //monsterHealthPoints[0] = 10;
    //monsterAttackPoints[0] = 12;
    //monsterDefencePoints[0] = 14;

    Monster[] addMonster(Monster[] oldMonsters, Monster monsterToAdd)
        {
            // This function takes two arguments. The first is the array of monsters
            // The second is the monster to add to the array of monsters
            // finally a new array of monsters is returned.
            int a = monsters.Length;
            int numberOfMonsters = oldMonsters.Length;
            Monster[] newMonsters = new Monster[numberOfMonsters + 1];
            for (int l = 0; l < numberOfMonsters; l++)
            {
                newMonsters[l] = oldMonsters[l];
            }
            newMonsters[numberOfMonsters] = monsterToAdd;
            return newMonsters;

        }

        Monster parseRow(string monsterRow)
        {
            var cols = monsterRow.Split(',');
            Monster m = new Monster();

            for (int k = 0; k < cols.Length; k++)
            {
                Console.WriteLine("Inner foreach loop  {0} col: {1}", k, cols[k]);
                switch (k)
                {
                    case 0:
                        // Name
                        m.Name = cols[k];
                        //monsterNames[index] = cols[k];
                        break;
                    case 1:
                        // Health
                        m.Health = int.Parse(cols[k]);
                        //monsterHealthPoints[index] = int.Parse(cols[k]);
                        break;
                    case 2:
                        // Attack
                        //m.Attack = int.Parse(cols[k]);
                        //monsterAttackPoints[index] = int.Parse(cols[k]);
                        break;
                    case 3:
                        // Defence
                        m.Defense = int.Parse(cols[k]);
                        //monsterDefencePoints[index] = int.Parse(cols[k]);
                        break;

                }
            }
            return m;
        }

        //void extendMonsterArrays()
        //{
        //    // öka antalet element i alla monster-arrayr med ett
        //    int numberOfMonsters = monsterNames.Length;
        //    string[] tempMonsterNames = new string[numberOfMonsters + 1];
        //    int[] tempMonsterHealthPoints = new int[numberOfMonsters + 1];
        //    int[] tempMonsterAttackPoints = new int[numberOfMonsters + 1];
        //    int[] tempMonsterDefencePoints = new int[numberOfMonsters + 1];

        //    for (int l = 0; l < numberOfMonsters; l++)
        //    {
        //        tempMonsterNames[l] = monsterNames[l];
        //        tempMonsterHealthPoints[l] = monsterHealthPoints[l];
        //        tempMonsterAttackPoints[l] = monsterAttackPoints[l];
        //        tempMonsterDefencePoints[l] = monsterDefencePoints[l];
        //    }
        //    monsterNames = tempMonsterNames;
        //    monsterHealthPoints = tempMonsterHealthPoints;
        //    monsterAttackPoints = tempMonsterAttackPoints;
        //    monsterDefencePoints = tempMonsterDefencePoints;
        //}

        //monsterNames[1] = "Franke";
        //monsterHealthPoints[1] = 18;
        //monsterAttackPoints[1] = 14;
        //monsterDefencePoints[1] = 10;

        // Läs in filen
        // plocka ut en rad i taget
        //void parseRow(string monsterRow, int index)
        //{
        //    var cols = monsterRow.Split(',');
        //    for (int k = 0; k < cols.Length; k++)
        //    {
        //        Console.WriteLine("Inner foreach loop  {0} col: {1}", k, cols[k]);
        //        switch (k)
        //        {
        //            case 0:
        //                // Name
        //                monsterNames[index] = cols[k];
        //                break;
        //            case 1:
        //                // Health
        //                monsterHealthPoints[index] = int.Parse(cols[k]);
        //                break;
        //            case 2:
        //                // Attack
        //                monsterAttackPoints[index] = int.Parse(cols[k]);
        //                break;
        //            case 3:
        //                // Defence
        //                monsterDefencePoints[index] = int.Parse(cols[k]);
        //                break;

        //        }
        //    }
        //}

        //var rows = input.Split('\n');
        //Console.WriteLine("Outer For loop:");

        //foreach (var row in rows)
        //{
        //    monsters = addMonster(monsters, parseRow(row));
        //}
        //for (int j = 0; j < rows.Length; j++)
        //{
        //    //Console.WriteLine("Outer loop {0}: {1}", j, rows[j]);
        //    //extendMonsterArrays();
        //    //parseRow(rows[j], j);

        //    monsters = addMonster(monsters, parseRow(rows[j]));

        //}
        
        Console.WriteLine("Menu system");
        bool mainMenu = true;
        while (mainMenu)
        {
            Console.WriteLine("Welcome to Monsters Inc. There are {0} monsters in the database.", monsters.Length);
            Console.WriteLine("Please select one of the following");
            Console.WriteLine("1. List all monsters");
            Console.WriteLine("2. Create new monster");
            Console.WriteLine("3. Update new monster");
            Console.WriteLine("E. Exit");
            Console.Write("----> ");
            string? choice = Console.ReadLine().ToUpper(); 
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Listing all monsters");
                    // monsters is an array of instances of Monster
                    // each monster has an array of instances of Attack called Attacks
                    for (int i = 0; i < monsters.Length; i++)
                    {
                        //Console.WriteLine("{0}: HP: {1}, AP: {2}, DP: {3}", monsterNames[i], monsterHealthPoints[i], monsterAttackPoints[i], monsterDefencePoints[i]);
                        Console.WriteLine("{0}: HP: {1}, DP: {2}", monsters[i].Name, monsters[i].Health, monsters[i].Defense);
                        Attack[] monsterAttacks = monsters[i].Attacks;
                        for (int j = 0; j < monsterAttacks.Length; j++)
                        {
                            Console.WriteLine("  {0}: {1} - {2}", j + 1, monsterAttacks[j].Name, monsterAttacks[j].AttackValue);
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
                    //string newMonster = "Tobbe,20,10,12";
                    monsters = addMonster(monsters, parseRow("Tobbe,20,10,12"));
                    //extendMonsterArrays();
                    //parseRow(newMonster, monsterNames.Length - 1);
                    // saveMonsters();

                    Console.WriteLine("Monster successfully added to database");
                    break;
                case "3":
                    Console.WriteLine("Update selected");
                    Console.WriteLine();
                    Monster updatedMonster = monsters[1];
                    Attack updatedAttack = monsters[1].Attacks[0];

                    Console.WriteLine("Monster[1].Name: before {0}", monsters[1].Name);
                    Console.WriteLine("updatedMonster.Name: before {0}", updatedMonster.Name);
                    Console.WriteLine("monsters[1].Attacks[0].AttackValue before {0}", monsters[1].Attacks[0].AttackValue);
                    Console.WriteLine("updatedAttack.AttackValue before {0}", updatedAttack.AttackValue);
                         
                    updatedMonster.Name = "Johan";
                    updatedAttack.AttackValue = 15;

                    Console.WriteLine("Monster[1].Name: after {0}", monsters[1].Name);
                    Console.WriteLine("updatedMonster.Name: after {0}", updatedMonster.Name);
                    Console.WriteLine("monsters[1].Attacks[0].AttackValue after {0}", monsters[1].Attacks[0].AttackValue);
                    Console.WriteLine("updatedAttack.AttackValue after {0}", updatedAttack.AttackValue);

                    //monsters[1] = updatedMonster;
                    //Console.WriteLine("Monster[1].Name: final {0}", monsters[1].Name);
                    //Console.WriteLine("updatedMonster.Name: final {0}", updatedMonster.Name);
                    Console.ReadLine();
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

    public class Attack
    {
        private string name;
        private int attackvalue;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int AttackValue
        {
            get
            {
                return attackvalue;
            }
            set
            {
                attackvalue = value;
            }
        }
    }

    public class Monster
    {

        private string name;
        private int health;
        //private int attack;
        private int defense;
        private Attack[] attacks;

        public Attack[] Attacks {
            get
            {
                return attacks;
            }
            set
            {
                attacks = value;
            }
         }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        //public int Attack
        //{
        //    get
        //    {
        //        return attack;
        //    }
        //    set
        //    {
        //        attack = value;
        //    }
        //}
        public int Defense
        {
            get
            {
                return defense;
            }
            set
            {
                defense = value;
            }
        }
    }
    //public struct Monster
    //{

    //    private string name;
    //    private int health;
    //    private int attack;
    //    private int defense;

    //    public string Name 
    //    {
    //        get
    //        {
    //            return name;
    //        }
    //        set
    //        {
    //            name = value;
    //        }
    //    }

    //    public int Health
    //    {
    //        get
    //        {
    //            return health;
    //        }
    //        set
    //        {
    //            health = value;
    //        }
    //    }
    //    public int Attack
    //    {
    //        get
    //        {
    //            return attack;
    //        }
    //        set
    //        {
    //            attack = value;
    //        }
    //    }
    //    public int Defense
    //    {
    //        get
    //        {
    //            return defense;
    //        }
    //        set
    //        {
    //            defense = value;
    //        }
    //    }
    //}
}
