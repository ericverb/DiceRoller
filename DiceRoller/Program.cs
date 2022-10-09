bool isValid;
int userDiceSides;
bool rollAgain = true;

do
{
    Console.WriteLine(
        $"Welcome to Dice Roller. Enter the number of sides your Dice will have, game is best played with 6 sided dice! {Environment.NewLine}");
    isValid = int.TryParse(Console.ReadLine(), out userDiceSides);
} while (!isValid);


bool rollDice;
do
{
    Console.WriteLine($"Please roll the dice. Type r to roll! {Environment.NewLine}");
    rollDice = Console.ReadLine()!.Trim().ToLower() == "r";
} while (!rollDice);


while (rollAgain)
{
    int userDice1 = Dice1(userDiceSides);
    int userDice2 = Dice2(userDiceSides);


    if (userDiceSides == 6)
    {
        int dice6SideTotal = userDice1 + userDice2;
        Console.WriteLine(
            $"You rolled and {userDice1} and {userDice2} for a total of {dice6SideTotal}!{Environment.NewLine}");
        string sixSidedResults = SixSidedDice(userDice1, userDice2);

        if (sixSidedResults != "")
        {
            Console.WriteLine($"{sixSidedResults} {Environment.NewLine}");
        }
    }
    else
    {
        int diceTotal = userDice1 + userDice2;
        Console.WriteLine(
            $"You rolled and {userDice1} and {userDice2} for a total of {diceTotal}! {Environment.NewLine} ");
        string userSidedResults = UserSidedDice(userDice1, userDice2);
        Console.WriteLine($"{userSidedResults} {Environment.NewLine}");
    }

    Console.WriteLine("Would you like to roll the dice again! type r to roll!");
    rollAgain = Console.ReadLine()!.Trim().ToLower() == "r";

    if (!rollAgain)
    {
        Environment.Exit(0);
    }
}


string SixSidedDice(int dice1, int dice2)
{
    int sixSidedResults = dice1 + dice2;

    switch (sixSidedResults)
    {
        case 2:

            string snakeEyes = $"Snake Eyes: Two 1s!{Environment.NewLine}";
            snakeEyes = snakeEyes + "Craps you rolled a total of 2!";
            return snakeEyes;

        case 3:
            string aceDeuce = $"Ace Deuce: A 1 and 2!{Environment.NewLine}";
            aceDeuce = aceDeuce + "Craps you rolled a total of 3!";
            return aceDeuce;

        case 7:
            string win7 = "Win: A total of 7!";
            return win7;

        case 11:
            string win11 = "Win: A total of 11!";
            return win11;

        case 12:
            string craps = "Craps you rolled a total of 12!";
            return craps;
    }

    string emptyMessage = "";
    return emptyMessage;
}


string UserSidedDice(int dice1, int dice2)
{
    int customSidedDice = dice1 + dice2;

    switch (customSidedDice)
    {
        case > 0 and <= 20:
            string beginner =
                $"You are a beginner and have rolled under 100 please come back when you have practiced more!{Environment.NewLine}";
            return beginner;

        case > 20 and <= 50:
            string rookieDiceRoller = $"You are a rookie dice roller and need to practice!{Environment.NewLine}";
            return rookieDiceRoller;

        case > 50:
            string masterDiceRoller = $"You are a Master Dice Roller and have WON the game! {Environment.NewLine}";
            return masterDiceRoller;
    }

    string lowestScoreEver =
        $"You are not very good at this game and have rolled the lowest score ever! {Environment.NewLine}";
    return lowestScoreEver;
}


int Dice1(int diceSides)
{
    Random random = new Random();
    int dice1 = random.Next(1, diceSides);
    return dice1;
}

int Dice2(int diceSides)
{
    Random random = new Random();
    int dice2 = random.Next(1, diceSides);
    return dice2;
}