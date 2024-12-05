namespace Blackjack;

public static class Game
{
    //private static int[] _dealtCards = new int[13];

    public static int DealCard()
    {
        Random rnd = new Random(); // create an instance of random 
        int newCard = rnd.Next(1,10); // generate a random number
        return newCard; 
    }

    public static bool GameOver(int score1, int score2)
    {
        // check if either players' score is above 21 
        if (score1 >= 21 || score2 >= 21) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int CalculateScore(LinkedList<int> currentHand)
    {
        int score = 0; // start score count at zero 

        foreach (var card in currentHand)
        {
            score += card;
        }
        
        // ace can be worth 1 or 11
        // check if the hand contains an ace (1) and if using it as 11 would end game
        if (currentHand.Contains(1) && score + 10 < 21) // default to ace as 11 whenever possible
        {
            score += 10;
        }

        return score;
    }

    public static void DetermineResults(int currentPlayerScore, int currentDealerScore)
    {
        if (currentPlayerScore == currentDealerScore || (currentPlayerScore == 21 && currentDealerScore == 21))
        {
            Console.WriteLine("It's a push! Nobody Wins!");
        }
        else if (currentPlayerScore > 21)
        {
            Console.WriteLine("You lose! It's a bust!");
        }
        else if (currentDealerScore < 21 && currentPlayerScore < currentDealerScore)
        {
            Console.WriteLine("You lose!");
        }
        else
        {
            Console.WriteLine("You win! Congratulations!");
        }
    }
}