namespace BowlingGameKata.Code
{
    public class Hand
    {
        private readonly Combination combination;

        public Hand(string card1, string card2, string card3, string card4, string card5)
        {
            combination = FindBestCombination(card1, card2, card3, card4, card5);
        }

        public bool Beats(Hand hand)
        {
            return combination.Beats(hand.combination);
        }

        private Combination FindBestCombination(string card1, string card2, string card3, string card4, string card5)
        {
            return new HighCard(card1, card2, card3, card4, card5);
        }
    }
}