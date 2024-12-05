using Blackjack;

LinkedList<int> playerCards = new LinkedList<int>();
LinkedList<int> dealerCards = new LinkedList<int>();

playerCards.AddLast(Game.DealCard());
playerCards.AddLast(Game.DealCard());

dealerCards.AddLast(Game.DealCard());
dealerCards.AddLast(Game.DealCard());

Console.WriteLine("Welcome to Blackjack!\n");
Console.WriteLine("The dealer deals everyone two cards.");
Console.WriteLine("The dealer reveals his first card: {0}", dealerCards.First.Value);
Console.WriteLine("Your cards are: {0} and {1}", playerCards.First.Value, playerCards.Last.Value);

int currentPlayerScore = Game.CalculateScore(playerCards);
int currentDealerScore = Game.CalculateScore(dealerCards);

if(Game.GameOver(currentPlayerScore, currentDealerScore ))
{
    Game.DetermineResults(currentPlayerScore, currentDealerScore);
}
else
{
    while (!Game.GameOver(currentPlayerScore, currentDealerScore))
    {
        Console.Write("Would you like to draw another card? Y/N");
        string input = Console.ReadLine();

        if (input.ToLower() == "y")
        {
            int newCard = Game.DealCard();
            Console.WriteLine("Your new card is {0}.", newCard);
            playerCards.AddLast(newCard);
        }
        else
        {
            break;
        }
    }
    Console.Clear();
    Console.WriteLine("Your final hand is: ");
    foreach (var card in playerCards)
    {
        Console.Write(card + " ");
    }
    currentPlayerScore = Game.CalculateScore(playerCards);
    if (Game.GameOver(currentPlayerScore, currentDealerScore))
    {
        Game.DetermineResults(currentPlayerScore, currentDealerScore);
    }
    else
    {
        Console.WriteLine("Dealer reveals his second card.");
        Console.WriteLine("The dealer's hand is: ");
        foreach (var card in dealerCards)
        {
            Console.Write(card + " ");
        }

        while (currentDealerScore < 16)
        {
            Console.WriteLine("Dealer will draw another card!");
            int newCard = Game.DealCard();
            Console.WriteLine("The dealer draws a {0}.", newCard);
            dealerCards.AddLast(newCard);
            currentDealerScore = Game.CalculateScore(dealerCards);
        }
        
        
        Console.WriteLine("That's it!");
        Console.Write("The dealer's final hand is: ");
        foreach (var card in dealerCards)
        {
            Console.Write(card + " ");
        }
        Console.Write("\nYour final hand is: ");
        foreach (var card in playerCards)
        {
            Console.Write(card + " ");
        }
        currentPlayerScore = Game.CalculateScore(playerCards);
        currentDealerScore = Game.CalculateScore(dealerCards);
        
        Console.WriteLine("\nThe dealer's final score is {0}.", currentDealerScore);
        Console.WriteLine("The player's final score is {0}.", currentPlayerScore);
        
        Game.DetermineResults(currentPlayerScore, currentDealerScore);
    }
}

