using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateACharacter
{
    // **************************************************
    //
    // Title: Mini RPG Create a Character
    // Description: Create Your Own RPG Character and Run a Mini Choose Your Own Adventure
    // Application Type: Console
    // Author: Witt, Stephanie
    // Dated Created: 4/10/2021
    // Last Modified: 4/17/2021
    //
    // **************************************************

    public enum STRENGTH
    {
        WIZARD = 1,
        PALADIN = 2,
        WARRIOR = 3,
        CHEAT = 99,
    }
    public enum INTELLIGENCE
    {
        WIZARD = 3,
        PALADIN = 2,
        WARRIOR = 1,
        CHEAT = 99,
    }
    class Program
    {
        private static string classChosen;
        private static int totalIntelligence;
        private static int totalStrength;
        private static string weaponChoice;
        private static int bonusRoll;
        private static string userName;

        static void Main(string[] args)
        {
            FormattingSetTheme();
            FormattingDisplayWelcomeScreen();
            FormattingDisplayOpeningScreen();
            FormattingDisplayMenuScreen();
        }



        #region FORMATTING

        /// <summary>
        /// *****************************************************************
        /// *                     FORMATTING METHODS                        *
        /// *****************************************************************
        /// </summary>
    private static void FormattingDisplayOpeningScreen()
        {
            FormattingDisplayHeader("Your Journey Begins Here.");

            Console.WriteLine("\tEmbark on a journey to find the mysterious orb");
            Console.WriteLine("\tIt's rumored to have the power to save your village from doom.");
            Console.WriteLine("\tHowever, it's guarded by tricks and treachery, so you must use your wits and strength to overcome.");
            Console.WriteLine();
            Console.WriteLine("\tCreate your character and find the right path to victory.");

            FormattingDisplayContinuePrompt();
        }
    private static void FormattingDisplayWelcomeScreen()
        {
            Console.WriteLine("\t                          )      \\    /      (");
            Console.WriteLine("\t                         /|\\      )\\_/(     /|\\");
            Console.WriteLine("\t*                       / | \\    (/\\|/\\)   / | \\                      *");
            Console.WriteLine("\t|`.____________________/__|__o____\\`|'/___o__|__\\___________________.'|");
            Console.WriteLine("\t|                           '^`    \\|/   '^`                          |");
            Console.WriteLine("\t|                                   V                                 |");
            Console.WriteLine("\t|                                                                     |");
            Console.WriteLine("\t|                        Mini RPG Character Creator                   |");
            Console.WriteLine("\t|                                                                     |");
            Console.WriteLine("\t|                                                                     |");
            Console.WriteLine("\t| ._________________________________________________________________. |");
            Console.WriteLine("\t|'               l    /\\ /        \\\\         \\ /\\   l                `|");
            Console.WriteLine("\t*                l  /   V          ))         V   \\ l                 *");
            Console.WriteLine("\t                 l/               //               \\I");
            Console.WriteLine("\t                                  V");
            Console.WriteLine("\t");

            FormattingDisplayContinuePrompt();
        }
        private static void FormattingSetTheme()
        {

            ConsoleColor openingScreenBackground = ConsoleColor.Gray;
            ConsoleColor openingScreenForeground = ConsoleColor.DarkRed;
            Console.BackgroundColor = openingScreenBackground;
            Console.ForegroundColor = openingScreenForeground;
            Console.SetWindowSize(175, 40);
        }
        private static void FormattingDisplayMenuScreen()
        {
            string menuChoice;
            bool quitMenu = false;

            do
            {
                FormattingDisplayHeader("Main Menu");

                Console.WriteLine("\ta) Character Details");
                Console.WriteLine("\tb) Character Class");
                Console.WriteLine("\tc) Bonus Roll");
                Console.WriteLine("\td) Go on a Journey");
                Console.WriteLine("\tq) Quit"); 
                Console.WriteLine();
                Console.Write("\t\tEnter Choice: ");
                menuChoice = Console.ReadLine().ToLower();

                switch (menuChoice)
                {
                    case "a":
                        CreateCharacterSetNameAndDetails();
                        break;

                    case "b":
                        CreateCharacterSetClass();
                        break;

                    case "c":
                        CreateCharacterBonusRoll();
                        break;

                    case "d":
                        ChoosePathWelcome();
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        FormattingDisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);

            FormattingDisplayContinuePrompt();
        }

        private static void FormattingDisplayHeader(string header)
        {
            Console.WriteLine();
            Console.WriteLine("\t-----------------------------------------------");
            Console.WriteLine($"\t\t{header}");
            Console.WriteLine("\t-----------------------------------------------");
            Console.WriteLine();
        }
        private static void FormattingDisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\t<--------Press any key to continue-------->");
            Console.ReadKey();
            Console.Clear();
        }
        private static void FormattingDisplayDeathScreen(string deathSpecificMessage, string deathSpecificMessage2)
        {
            FormattingDisplayHeader($"{userName} DIED");

            Console.WriteLine($"\t{deathSpecificMessage}");
            Console.WriteLine($"\t{deathSpecificMessage2}");
            Console.WriteLine("");
            Console.WriteLine("\t\t             ___          ");
            Console.WriteLine("\t\t            /   \\\\        ");
            Console.WriteLine("\t\t       /\\\\ | . . \\\\       ");
            Console.WriteLine("\t\t     ////\\\\|     ||       ");
            Console.WriteLine("\t\t   ////   \\\\ ___//\\       ");
            Console.WriteLine("\t\t  ///      \\\\      \\      ");
            Console.WriteLine("\t\t ///       |\\\\      |     ");
            Console.WriteLine("\t\t//         | \\\\  \\   \\   ");
            Console.WriteLine("\t\t/          |  \\\\  \\   \\   ");
            Console.WriteLine("\t\t           |   \\\\ /   /   ");
            Console.WriteLine("\t\t           |    \\/   /    ");
            Console.WriteLine("\t\t           |     \\\\/|     ");
            Console.WriteLine("\t\t           |      \\\\|     ");
            Console.WriteLine("\t\t           |       \\\\     ");
            Console.WriteLine("\t\t           |        |    ");
            Console.WriteLine("\t\t           |_________\\   ");
            Console.WriteLine("");
            Console.WriteLine("\tPress any key to return to the menu");
            Console.ReadKey();
            Console.Clear();
            FormattingDisplayMenuScreen();
        }
        private static void FormattingDisplayGoodEndingScreen(string goodSpecificMessage, string goodSpecificMessage2)
        {
            FormattingDisplayHeader($"{userName} WINS!");
            Console.WriteLine();
            Console.WriteLine($"\t{goodSpecificMessage}");
            Console.WriteLine($"\t{goodSpecificMessage2}");
            Console.WriteLine();
            Console.WriteLine("\t\t                ^    ^");
            Console.WriteLine("\t\t               / \\  //\\");
            Console.WriteLine("\t\t |\\___/|      /   \\//  .\\");
            Console.WriteLine("\t\t /O  O  \\__  /    //  | \\ \\");
            Console.WriteLine("\t\t/     /  \\/_/    //   |  \\  \\");
            Console.WriteLine("\t\t@___@'    \\/_   //    |   \\   \\ ");
            Console.WriteLine("\t\t   |       \\/_ //     |    \\    \\ ");
            Console.WriteLine("\t\t   |        \\///      |     \\     \\ ");
            Console.WriteLine("\t\t  _|_ /   )  //       |      \\     _\\");
            Console.WriteLine("\t\t '/,_ _ _/  ( ; -.    |    _ _\\.-~        .-~~~^-.");
            Console.WriteLine("\t\t ,-{        _      `-.|.-~-.           .~         `.");
            Console.WriteLine("\t\t  '/\\      /                 ~-. _ .-~      .-~^-.  \\");
            Console.WriteLine("\t\t     `.   {            }                   /      \\  \\");
            Console.WriteLine("\t\t   .----~-.\\        \\-'                 .~         \\  `. \\^-.");
            Console.WriteLine("\t\t  ///.----..>    c   \\             _ -~             `.  ^-`   ^-_");
            Console.WriteLine("\t\t    ///-._ _ _ _ _ _ _}^ - - - - ~                     ~--,   .-~");
            Console.WriteLine("\t\t                                                          /.-'");
            Console.WriteLine("");
            Console.WriteLine("\tPress any key to to return to the menu");
            Console.ReadKey();
            Console.Clear();
            FormattingDisplayMenuScreen();
        }
        private static void FormattingDisplayBadEndingScreen(string badSpecificMessage)
        {
            FormattingDisplayHeader($"{userName} LIVE TO JOURNEY AGAIN");
            Console.WriteLine();

            Console.WriteLine($"\t{badSpecificMessage}");
            Console.WriteLine(0);
            Console.WriteLine("\t\t                                ,-.");
            Console.WriteLine("\t\t                               (\"O_)");
            Console.WriteLine("\t\t                              / `-/");
            Console.WriteLine("\t\t                             /-. /");
            Console.WriteLine("\t\t                            /   )");
            Console.WriteLine("\t\t                           /   /  ");
            Console.WriteLine("\t\t              _           /-. /");
            Console.WriteLine("\t\t             (_)\" -._ /   )");
            Console.WriteLine("\t\t               \" -._ \\\"-'\"\"( )/    ");
            Console.WriteLine("\t\t                   \" -/ \"-._\" `. ");
            Console.WriteLine("\t\t                    /     \" -.'._");
            Console.WriteLine("\t\t                   /\\       /-._\" -._");
            Console.WriteLine("\t\t    _,---...__    /  ) _,-\" / \"-(_)");
            Console.WriteLine("\t\t___<__(|) _   \"\"-/  / /   /");
            Console.WriteLine("\t\t '  `----' \"\"-.   \\/ /   /");
            Console.WriteLine("\t\t               )  ] /   /");
            Console.WriteLine("\t\t       ____..-'   //   /                       )");
            Console.WriteLine("\t\t   ,-\"\"      __.,'/   /   ___                 /,");
            Console.WriteLine("\t\t  /    ,--\"\"/  / /   /,-\"\"   \"\"\" -.          , '/");
            Console.WriteLine("\t\t [    (    /  / /   /  ,.---,_   `._   _,-','");
            Console.WriteLine("\t\t  \\    `-./  / /   /  /       `-._  \"\"\", -'");
            Console.WriteLine("\t\t   `-._  /  / /   /_,'  ");
            Console.WriteLine("\t\t       \" /  / /   / \"  ");
            Console.WriteLine("\t\t       /  / /   /");
            Console.WriteLine("\t\t      /  / /   /  o!O");
            Console.WriteLine("\t\t     /  |,'   /  ");
            Console.WriteLine("\t\t    :   /    /");
            Console.WriteLine("\t\t    [  /   ,'   ");
            Console.WriteLine("\t\t    | /  ,'");
            Console.WriteLine("\t\t    |/,-'");
            Console.WriteLine("\t\t    P'");
            Console.WriteLine("");
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey();
            Console.Clear();
            FormattingDisplayMenuScreen();
        }
        private static void FormattingSetStrength()
        {
            var rand = new Random();
            int randomStrength = rand.Next(0, 1); ;

            if (classChosen == "paladin")
            {
                totalStrength = (int)(bonusRoll + randomStrength + STRENGTH.PALADIN);
            }
            else if (classChosen == "wizard")
            {
                totalStrength = (int)(bonusRoll + randomStrength + STRENGTH.WIZARD);
            }
            else if (classChosen == "warrior")
            {
                totalStrength = (int)(bonusRoll + randomStrength + STRENGTH.WARRIOR);
            }
            else
            {
                totalStrength = (int)INTELLIGENCE.CHEAT;
            }
        }
        private static void FormattingSetIntelligence()
        {
            var rand = new Random();
            int randomIntelligence = rand.Next(0, 1);

            if (classChosen == "paladin")
            {
                totalIntelligence = (int)(bonusRoll + randomIntelligence + INTELLIGENCE.PALADIN);
            }
            else if (classChosen == "wizard")
            {
                totalIntelligence = (int)(bonusRoll + randomIntelligence + INTELLIGENCE.WIZARD);
            }
            else if (classChosen == "warrior")
            {
                totalIntelligence = (int)(bonusRoll + randomIntelligence + INTELLIGENCE.WARRIOR);
            }
            else
            {
                totalIntelligence = (int)INTELLIGENCE.CHEAT;
            }
        }
        private static int FormattingValidateInteger(string prompt, int minimum, int maximum)
        {
            bool validResponse;
            int numberEntered;

            do
            {
                validResponse = true;

                Console.Write($"\t{prompt} ");

                if (!int.TryParse(Console.ReadLine(), out numberEntered))
                {
                    Console.WriteLine("\tPlease enter a valid number");
                    FormattingDisplayContinuePrompt();
                    Console.Clear();

                    validResponse = false;
                }
                else if (numberEntered < minimum || numberEntered > maximum)
                {
                    Console.WriteLine($"\tPlease enter a number between {minimum} and {maximum}");
                    FormattingDisplayContinuePrompt();
                    Console.Clear();

                    validResponse = false;
                }

            } while (!validResponse);

            return numberEntered;
        }
        private static string FormattingValidateTwoStrings(string prompt, string answerOne, string answerTwo)
        {
            string userResponse;
            bool validResponse;

            do
            {
                validResponse = true;

                Console.Write("\t" + prompt + " ");
                userResponse = Console.ReadLine().ToLower();

                if (userResponse != answerOne && userResponse != answerTwo)
                {
                    validResponse = false;

                    Console.WriteLine();
                    Console.WriteLine($"\tPlease enter a valid response of {answerOne} or {answerTwo}");
                    FormattingDisplayContinuePrompt();
                }
            } while (!validResponse);

            return userResponse;
        }
        #endregion

        #region CREATE CHARACTER

        /// <summary>
        /// *****************************************************************
        /// *                     CREATE CHARACTER METHODS                         *
        /// *****************************************************************
        /// </summary>
        private static void CreateCharacterSetNameAndDetails()
        {
  
            Console.Clear();

            FormattingDisplayHeader("Character Creator");

            Console.WriteLine("\tWelcome to the character creator!");
            Console.WriteLine("\tFirst, you have to choose a name.");
            Console.WriteLine();
            Console.Write("\tEnter your name: ");
            userName = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine($"\tNice to meet you, {userName}!");

            FormattingDisplayContinuePrompt();

        }
        private static void CreateCharacterSetClass()
        {
            string userResponse;
            bool validResponse;

            Console.Clear();

            FormattingDisplayHeader("Choose a Class");
            do
            {
                validResponse = true;
                do
                {
                    validResponse = true;
                    Console.WriteLine("\tNext, you need to choose a class.");
                    Console.WriteLine("\tThere are three classes - Wizard, Paladin, and Warrior.");
                    Console.WriteLine();
                    Console.Write("\tLearn more about each class [Enter the class to learn more]: ");
                    classChosen = Console.ReadLine().ToLower();

                if (classChosen != "wizard" && classChosen != "paladin" && classChosen != "warrior" && classChosen != "cheat")
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a valid response.");

                    FormattingDisplayContinuePrompt();

                    validResponse = false;
                }
                }
                while (!validResponse);

                switch (classChosen)
                {
                    case "wizard":
                        Console.WriteLine();
                        Console.WriteLine("\tThe Wizard: Become wise and better understand the world around you.");
                        Console.WriteLine("\tAlthough not physically strong, the Wizard can use it's wisdom to get past tough puzzles.");
                        Console.WriteLine();
                        break;
                    case "paladin":
                        Console.WriteLine();
                        Console.WriteLine("\tThe Paladin: A balanced class, the Paladin is kind, but can also weild a sword.");
                        Console.WriteLine("\tAlthough this can be advantageous in some situations, bad luck can also have a bigger impact.");
                        Console.WriteLine();
                        break;
                    case "warrior":
                        Console.WriteLine();
                        Console.WriteLine("\tThe Warrior: As strong as ever, the warrior can cut through any enemy.");
                        Console.WriteLine("\tBecause your father focused too much on brute force as a child, your social skills aren't as developed as they should be.");
                        Console.WriteLine();
                        break;
                    case "cheat":
                        Console.WriteLine();
                        Console.WriteLine("\tWant to win? Cheat.");
                        Console.WriteLine();
                        break;
                }
                
                userResponse = FormattingValidateTwoStrings("Do you choose this class?", "yes", "no");

                if (userResponse == "no")
                {
                    Console.Clear();
                    validResponse = false;
                }
            }
            while (!validResponse);

            FormattingSetIntelligence();
            FormattingSetStrength();

            Console.WriteLine();
            Console.WriteLine("\tNext, you will choose a weapon.");

            FormattingDisplayContinuePrompt();

            CreateCharacterChooseWeapon();
        }
        private static void CreateCharacterChooseWeapon()
        {
            bool validResponse = false;

            FormattingDisplayHeader("Choose a Weapon");

            do
            {
                validResponse = true;

                Console.WriteLine("\tWhat weapon would you like to choose?");
                Console.WriteLine();
                Console.Write("\tYou can choose a \"staff\", a \"sword\", or an \"axe\": ");
                weaponChoice = Console.ReadLine().ToLower();

                if (weaponChoice != "staff" && weaponChoice != "sword" && weaponChoice != "axe")
                {
                    Console.WriteLine();
                    Console.WriteLine("Please choose a valid weapon.");
                    FormattingDisplayContinuePrompt();
                    validResponse = false;
                }
            }
            while (!validResponse);

            Console.WriteLine();
            Console.WriteLine("\tYou chose the {0}.", weaponChoice);
            Console.WriteLine("\tYou will likely need this weapon throughout your journey. Use it well.");

            FormattingDisplayContinuePrompt();
        }
        private static void CreateCharacterBonusRoll()
        {
            string userResponse;
            bool validResponse;

            Console.Clear();

            FormattingDisplayHeader("Get a Bonus Roll");

            do
            {
                validResponse = true;

                Console.WriteLine("\tHere, you can get a bonus roll for strength and intelligence.");
                Console.WriteLine();

                var rand = new Random();
                int randomNumber = rand.Next(1, 5);

                bonusRoll = randomNumber;

                Console.WriteLine($"\tYou get a bonus of {bonusRoll} points to your strength and intelligence.");
                Console.WriteLine();
                userResponse = FormattingValidateTwoStrings("Do you want to reroll?", "yes", "no");

                if (userResponse == "yes")
                {
                    Console.Clear();
                    validResponse = false;
                }
            }
            while (!validResponse);

            FormattingDisplayContinuePrompt();

        }

        #endregion

        #region CHOOSE PATH

        /// <summary>
        /// *****************************************************************
        /// *                     CHOOSE PATH METHODS                         *
        /// *****************************************************************
        /// </summary>
        private static void ChoosePathWelcome()
        {
            string userResponse;

            Console.Clear();

            FormattingDisplayHeader("An Adventure Simulation");

            Console.WriteLine("\tWelcome to the Quest of the Mountain.");
            Console.WriteLine("\tHere, you'll make choices to in order to get riches...or a special item.");
            Console.WriteLine("\tHowever, there are lots of opportunities to lose, so try many times if you fail!");
            Console.WriteLine();
            Console.WriteLine("\tBe sure your class is set, or else it may be impossible to receive a good ending.");
            Console.WriteLine();
            userResponse = FormattingValidateTwoStrings("Would you like to begin?", "yes", "no");

            FormattingDisplayContinuePrompt();

            if (userResponse == "yes") 
            {
                ChoosePathStoreShopIntelligenceCheck();
            }
            else 
            {
                FormattingDisplayMenuScreen();
            }

        }
        private static void ChoosePathStoreShopIntelligenceCheck()
        {
            string userResponse;

            Console.Clear();

            FormattingDisplayHeader("The Beginning");

            Console.WriteLine("\tYou find yourself at the base of a tall, foggy mountain.");
            Console.WriteLine("\tThe area around you is densly forested, but you can see it thinning as the mountain rises.");
            Console.WriteLine("\tJust to the left is a small bartering station, and a stout man eagerly approaches you from the doorway.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("Need a Horse?");

            Console.WriteLine("\t\"I have a wonderful horse for sale, and at a wonderful price\" he says.");
            Console.WriteLine("\tHe gives the price. A horse would be an excellent companion for your trip, but you don't have enough money.");
            Console.WriteLine();
            userResponse = FormattingValidateTwoStrings("Do you try to barter him down?", "yes", "no");

            FormattingDisplayContinuePrompt();

            if (userResponse == "yes")
            {
                FormattingSetIntelligence();

                if (totalIntelligence > 4) 
                {
                    ChoosePathOneCliffChoice();
                }
                else
                {
                    ChoosePathTwoIntelligenceFailure();
                }
            }
            else
            {
                ChoosePathTwoCheckCliffStrengthCheck();
            }

            FormattingDisplayHeader("The Mountain");
        }
        private static void ChoosePathOneCliffChoice()
        {
            string userResponse;


            FormattingDisplayHeader("A Winning Bet");

            Console.WriteLine("\tThe man huffs, but is willing to give up his horse for the price you suggest.");
            Console.WriteLine("\tYou also buy food and other supplies to prepare you for your trek, and you set off into the fog.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("The Mysterious Cliff");

            Console.WriteLine("\tYou come upon a sudden cliff. It seems far too early in the trip to be running into such a precipice.");
            Console.WriteLine("\tYour horse seems really nervous, and resists when you try to move towards it to check it out.");
            Console.WriteLine("\tSomething about the cliff draws you in, though.");
            Console.WriteLine("\tDo you:");
            Console.WriteLine("");
            Console.WriteLine("\t\"A\" - Check it out");
            Console.WriteLine("\t\"B\" - Leave the cliff alone");
            Console.WriteLine("");
            userResponse = FormattingValidateTwoStrings("What do you choose?", "a", "b");

            FormattingDisplayContinuePrompt();

            if (userResponse == "a")
            {
                FormattingDisplayDeathScreen("You get off your horse and creep closer.", "It appears the cliff edge wasn't very stable, and the ground collapses beneath you.");
            }
            else
            {
                ChoosePathOneGuardChoice();
            }

        }
        private static void ChoosePathOneGuardChoice()
        {
            string userResponse;
            
            FormattingDisplayHeader("The Right Choice?");

            Console.WriteLine("\tYou safely edge away from the sudden dropoff, and your horse calms down.");
            Console.WriteLine("\tIt's usually best to listen to animals when they get nervous like that.");
            Console.WriteLine("\tInstead, you continue along the regular path, towards the rolling hills.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("The Gate");

            Console.WriteLine("\tAbout two miles in, you rise over the crest to find another sheer rock wall, with you at the bottom of it this time.");
            Console.WriteLine("\tAlthough tiny, you can see a gate embedded in it, and in front of that, a speck of a man.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("The Guard");

            Console.WriteLine("\tAs you arrive close enough, his hand slides to the sword at his hip.");
            Console.WriteLine("\t\"What brings you here?\" he bellows. \"Begone at once!\"");
            Console.WriteLine("\tIt seems the only way to continue on is through him.");
            Console.WriteLine();

            userResponse = FormattingValidateTwoStrings("Do you want to \"reason\" with the guad, or \"fight\" him?","reason","fight");

            FormattingDisplayContinuePrompt();

            if (userResponse == "reason")
            {
                FormattingSetIntelligence();

                if (totalIntelligence > 4)
                {
                    ChoosePathOneGuardIntelligenceCheckSuccess();
                }
                else
                {
                    ChoosePathOneGuardIntelligenceCheckFailure();
                }
            }
            else
            {
                FormattingSetStrength();

                if (totalStrength > 4)
                {
                    ChoosePathOneGuardStrengthCheck();
                }
                else
                {
                    FormattingDisplayDeathScreen("The guard parrys your strikes and knocks you over.", "He graciously offers you a permanent post in your troop, which you have no choice but to accept.");
                }
            }

        }
        private static void ChoosePathOneGuardIntelligenceCheckSuccess()
        {
            FormattingDisplayHeader("Persuasion");

            Console.WriteLine("\tYou choose to reason with the guard.");
            Console.WriteLine("\tYou tell him about all the good that would happen should your mission succeed.");
            Console.WriteLine("\tHe ponders your words.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("The Journey Continues");

            Console.WriteLine("\tAfter a long moment, he sighs.");
            Console.WriteLine("\t\"Very well.\" he says, resigned. \"You may pass. But understand, you may not live to return.\"");
            Console.WriteLine("\tHe steps away from the gate, and it opens on its own, as if he unlocked it with his mind.");

            FormattingDisplayContinuePrompt();

            ChoosePathOneFindingOrb();

        }
        private static void ChoosePathOneGuardIntelligenceCheckFailure()
        {
            FormattingDisplayHeader("Not So Witty After All");

            Console.WriteLine("\t\"Ha! Do you think I will accept such tripe?\" He draws his sword. \"Have at you!\"");
            Console.WriteLine("\tHe strikes!");

            FormattingSetStrength();

            FormattingDisplayContinuePrompt();

            if (totalStrength > 4)
                {
                    ChoosePathOneGuardStrengthCheck();
                }
                else
                {
                    FormattingDisplayDeathScreen("The guard parrys your strikes and knocks you over.", "He graciously offers you a permanent post in your troop, which you have no choice but to accept.");
                }

        }
        private static void ChoosePathOneGuardStrengthCheck()
        {

            FormattingDisplayHeader("Knocked Out");

            Console.WriteLine($"\tYou block with your weapon and when he staggers, you pounce him on the head.");
            Console.WriteLine("\tThe guard falls to the ground in a slump.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("Secretly Running Away");

            Console.WriteLine("\tHopefully he's just knocked out, but you can't stick around to determine that.");
            Console.WriteLine("\tYou hear confused voices to the east - likely his comrades.");
            Console.WriteLine("\tYou must hurry on before they notice the source of the tall man's battle cry.");

            FormattingDisplayContinuePrompt();

            ChoosePathOneFindingOrb();

        }
        private static void ChoosePathOneFindingOrb()
        {
            string userResponse;

            FormattingDisplayHeader("Dense Fog");

            Console.WriteLine("\tThe fog is dense beyond the wall, but you make your way through with your trusty horse.");
            Console.WriteLine("\tOnly a few miles ahead should be your destination, according your your map.");
            Console.WriteLine("\tHowever, it is extremely slow going with the fog, and you fear you may miss it.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("The Entrance");

            Console.WriteLine("\tFinally, you feel it. Even through the fog, there's the slightest wisp of air, the slightest pressure change.");
            Console.WriteLine("\tYou turn your horse toward it, and find the entrace, hidden by brush but big enough for you and your horse, as long as you lead it by rein.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("The Orb");

            Console.WriteLine("\tIn the cavern, only 25 or so feet in, you find the orb.");
            Console.WriteLine("\tIt glows a soft green, almost white, and lively tendrils of blue swirl on its surface.");
            Console.WriteLine("\tIt sits upon a dais with a script embedded in it. From here, you're not sure if you can read it.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("A Choice");

            Console.WriteLine("\tThis almost seems to easy, but your horse doesn't seem nervous. What do you do?");
            Console.WriteLine("");
            Console.WriteLine("\t\"A\" - Take the orb");
            Console.WriteLine("\t\"B\" - Read the dais");
            Console.WriteLine();
            userResponse = FormattingValidateTwoStrings("Which do you choose [A or B]?","a","b");

            if (userResponse == "a")
            {
                FormattingDisplayContinuePrompt();
                FormattingDisplayDeathScreen("You try to pick up the orb, but an imp appears, grinning.", "It casts a spell on you, and while you think you're still alive, it appears your mind is not your own anymore.");
            }
            else
            {
                FormattingDisplayContinuePrompt();
                ChoosePathOneReadDais();
            }

        }
        private static void ChoosePathOneReadDais()
        {
            string userResponse;

            FormattingDisplayHeader("Translating the Dais");

            Console.WriteLine("\tThe orb is tempting, but as easy as it was to get here, you suspect there's more to this quest than just taking it.");
            Console.WriteLine("\tLeading your horse closer, you lean in to take a look at the writing.");
            Console.WriteLine("\tIt's old and weathered, and in a language you only barely know from your mentor.");
            Console.WriteLine("\tIt will take some time, but you think you may be able to translate it. You're glad you brought several days worth of food.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("Translation frustration");

            Console.WriteLine("\tIt's taken a few hours, but you think you have a phrase - \"In this place...\"");
            Console.WriteLine("\tYou can already feel the frustration rising.");
            Console.WriteLine("\tPerhaps there's a nearby town that may be able to help you.");
            Console.WriteLine("\tYou get a sinking feeling in your stomach at the thought of leaving the orb now, though.");
            Console.WriteLine();

            userResponse = FormattingValidateTwoStrings("Do you \"stay\" or do you \"leave?\"","stay","leave");

            if (userResponse == "stay")
            {
                FormattingDisplayContinuePrompt();
                FormattingDisplayDeathScreen("You decide to continue working on the orb. Your supplies dry up, but you can't seem to leave now.", "You feel like you're under a spell, one that's impossible to break out of.");
            }
            else
            {
                FormattingDisplayContinuePrompt();
                ChoosePathOneLeaveForTown();
            }

        }
        private static void ChoosePathOneLeaveForTown()
        {
            string userResponse;

            FormattingDisplayHeader("Your Horse Finds Something");

            Console.WriteLine("\tYou start to leave, but as you get on your horse, you notice it chewing something.");
            Console.WriteLine("\tIt seems to be thoroughly enjoying a leather-bound notebook.");
            Console.WriteLine("\tTo its displeasure, you snatch the notebook from the horse's mouth.");
            Console.WriteLine("\tIt's a little damp, but the contents inside seem intact.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("A Lucky Break");

            Console.WriteLine("\tAs you had hoped, on the inside is what looks like months of translation work.");
            Console.WriteLine("\tYour excitement as you turn the pages turns to dread as the translators notes become increasingly hard to decipher.");
            Console.WriteLine("\tIt appears this adventurer very nearly gained the orb, but completely lost their mind.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("The Riddle");

            Console.WriteLine("\tThe notebook speaks of a riddle to solve, and you must tap the square rock behind the dais three times to be presented with the riddle.");
            Console.WriteLine("\tThis seems to be the point of no return. What do you do?");
            Console.WriteLine("");
            Console.WriteLine("\t\"A\" - Tap the rocks and solve the riddle");
            Console.WriteLine("\t\"B\" - Get out while you still have your sanity");
            Console.WriteLine();

            userResponse = FormattingValidateTwoStrings("Do you choose \"A\" or \"B\"?","a","b");

            FormattingDisplayContinuePrompt();

            if (userResponse == "a")
            {
                ChoosePathOneSolveRiddle();
            }
            else
            {
                FormattingDisplayBadEndingScreen("Salvaging your sanity is more important. You get on your horse and leave safetly.");
            }

        }
        private static void ChoosePathOneSolveRiddle()
        {
            string userResponse;

            FormattingDisplayHeader("Tapping the Rock");

            Console.WriteLine("\tYou have to do it. The orb is here, and it seems the only barrier is a riddle.");
            Console.WriteLine("\tYou tap the rock three times.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("Solving the Riddle");

            Console.WriteLine("\tA voice speaks out to you, as if out of your own head.");
            Console.WriteLine("\t\"Who is the one that teaches you? Speak aloud, when you have your answer.\"");
            Console.WriteLine();
            Console.Write("\tWhat do you say? ");
            userResponse = Console.ReadLine().ToLower();

            FormattingDisplayContinuePrompt();

            if (userResponse != "john velis" && userResponse != "velis" && userResponse != "john")
            {
                FormattingDisplayDeathScreen("It appears you answered wrong. An imp appears, grinning, and places you under a spell.", "You don't think you're getting out of this one.");
            }    
            else
            {
                FormattingDisplayGoodEndingScreen("An imp appears out of the wall, surprised. He lazily tosses you an orb, nearly identical to the one on the dais, and shrugs.", "Confused, you lead your horse out of the cave, but your confusion morphs into the joy of victory.");
            }
            
        }
        private static void ChoosePathTwoIntelligenceFailure()
        {
            FormattingDisplayHeader("A Failure");

            Console.WriteLine("\tThe stout man is unimpressed.");
            Console.WriteLine("\t\"Is that the best you can do? Don't make me laugh.\"");
            Console.WriteLine("\tHe waves you over to some of the \"discount\" wares, and keeps the horse's rein in his hands.");
            Console.WriteLine("\tYou buy why you need, and go on your way, on foot.");

            FormattingDisplayContinuePrompt();

            ChoosePathTwoCheckCliffStrengthCheck();

        }
        private static void ChoosePathTwoCheckCliffStrengthCheck()
        {
            int userResponse;
            
            FormattingDisplayHeader("A Tiring Journey");

            Console.WriteLine("\tWith no horse to ride, the hills tire you out.");
            Console.WriteLine("\tAlthough you have no speed, you still carry your weapon with you for safety.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("A Sudden Cliff");

            Console.WriteLine("\tThe trees are dense, leaving almost no room for undergrowth.");
            Console.WriteLine("\tAs you turn a corner, however, you come across a sudden loss of trees, and ground as well.");
            Console.WriteLine("\tThe cliff is a sheer drop, as if the earth's crust itself had cracked and fallen away.");
            Console.WriteLine("\tDespite the eeriness, you find yourself drawn toward the edge, curious about what's below.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("The Vulture");

            Console.WriteLine("\tWith nothing holding you back, you head towards the cliff.");
            Console.WriteLine("\tJust as you peek over the edge, a large, vulture-like bird swoops to your face, claws out.");
            Console.WriteLine("\tIt appears you don't have a choice but to fight.");
            Console.WriteLine("");
            userResponse = FormattingValidateInteger("How many times do you strike?", 0, 100);

            FormattingDisplayContinuePrompt();

            FormattingSetStrength();

            if (totalStrength > 4)
            {
                if (userResponse > 20)
                {
                    FormattingDisplayDeathScreen("You swing wildly, and the creature becomes annoyed at your excessive violence.", "It pecks you off the cliff.");
                }
                else
                {
                    ChoosePathTwoReadDaisIntelligenceCheck();
                }
            }    
            else
            {
                FormattingDisplayDeathScreen("The creature is stronger than expected. It swoops and knocks you off the edge of the cliff.", "You try to grab a branch, but fail. The branch had a large nest on it with eggs.");
            }

        }
        private static void ChoosePathTwoReadDaisIntelligenceCheck()
        {

            FormattingDisplayHeader("Fighting the Creature");

            switch (weaponChoice)
            {
                case "sword":
                    Console.WriteLine("\tYou slice through the air with your sword, and shreds of feathers go flying.");
                    break;
                case "axe":
                    Console.WriteLine("\tThe creature squawks as you pummel it with your axe.");
                    break;
                case "staff":
                    Console.WriteLine("\tThe creature only just barely dodges the lightning strikes emitting from your staff.");
                    break;
                default:
                    Console.WriteLine("\tYou whacked the bird with your fists and rocks.");
                    break;
            }

            Console.WriteLine("\tThe bird seems to weather the hits with little damage, but it's enough to scare it off.");
            Console.WriteLine("\tYou put away your weapon and continue on, no worse for wear except that you might have to rest a little bit earlier than expected.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("Avian Attack");

            Console.WriteLine("\tYou have bigger worries coming quickly, however.");
            Console.WriteLine("\tIt appears the bird had many avian friends who didn't appreciate your brazen display of strength.");
            Console.WriteLine("\tThey swarm around you, and attempt to peck at you while you try to escape.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("The Gate");

            Console.WriteLine("\tYou run through the woods, and suddenly appear at a gate, with a tall man.");
            Console.WriteLine("\tHe squeals something in a language you've never heard before, and the gate behind him swings open.");
            Console.WriteLine("\tYou both run through, and the gate swings shut.");
            Console.WriteLine("\tThe birds swing away from the gate as if repelled by some forcefield.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("An Omen");

            Console.WriteLine("\tThe tall man gives you a dirty look.");
            Console.WriteLine("\t\"You lucked out.\"");
            Console.WriteLine("\tHe walked back to the gate. It opened without him having touched it, and swung shut the same way.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("Where Am I?");

            Console.WriteLine("\tYou pull out your map. Based on the markings, you think you're heading in the right direction.");
            Console.WriteLine("\tYou continue on.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("The Mist");

            Console.WriteLine("\tAs you continue, the mist that permeated the area becomes thick and foggy.");
            Console.WriteLine("\tYou nearly trip over a wayward duck, which wearily honks at you. It appears to be lost.");
            Console.WriteLine("\tYou duck into the entrance of a cave to get your bearings.");
            Console.WriteLine("\tYou come across the orb, sitting on a dais.");

            FormattingDisplayContinuePrompt();

            FormattingDisplayHeader("A Lucky Break");

            Console.WriteLine("\tMarveled at the convenience of it all, you approach the dais.");
            Console.WriteLine("\tYou try to read the writing on the dais - the language reminds you of what your mother spoke as a child.");

            FormattingDisplayContinuePrompt();

            FormattingSetIntelligence();

            if (totalIntelligence > 3)
            {
                ChoosePathTwoFindTreasureStrengthCheck();
            }
            else
            {
                ChoosePathTwoReadDaisIntelligenceCheckFailure();
            }

        }
        private static void ChoosePathTwoReadDaisIntelligenceCheckFailure()
        {
            string userResponse;

            FormattingDisplayHeader("An Important Decision");

            Console.WriteLine("\tIt's just too weird of a dialect for you.");
            Console.WriteLine("\tYou debate over taking the orb or leaving it. What should you do?");
            Console.WriteLine("");
            Console.WriteLine("\tA - Take the orb");
            Console.WriteLine("\tB - Abandon the quest");

            FormattingDisplayContinuePrompt();

            userResponse = FormattingValidateTwoStrings("What do you choose?", "a", "b");

            if (userResponse == "a")
            {
                FormattingDisplayDeathScreen("You try to take the orb. It shocks you and you fall to the ground, paralyzed.", "An imp moves into your line of vision. It's grinning and holding an orb that looks a lot like the one in your hand.");
            }
            else
            {
                FormattingDisplayBadEndingScreen("You decide it's not worth the risk. You leave, disappointed but alive, and find the next town over to get more rumors on treasure.");
            }

        }
        private static void ChoosePathTwoFindTreasureStrengthCheck()
        {

            FormattingDisplayHeader("The Dais");

            Console.WriteLine("\tThe dais speaks of a treasure.");
            Console.WriteLine("\tIf you read it correctly, it appears to be written with some humor.");
            Console.WriteLine("\tThe orb appears to be delicate, but the way to obtain it is to lift the dais.");
            Console.WriteLine("\tIt wouldn't hurt to try.");

            FormattingDisplayContinuePrompt();

            FormattingSetStrength();

            if (totalStrength > 4)
            {
                FormattingDisplayGoodEndingScreen("You lift the dais, and the orb falls off and shatters. An imp appears, eyes narrowed in anger.", "It chucks a nearly identical orb at you, and disappears back into the rock wall. This must be the real orb.");
            }
            else
            {
                FormattingDisplayBadEndingScreen("The orb is too dangerous to touch, and the dais too heavy to lift. You walk away, defeated.");
            }

        }
        #endregion
    }
}
