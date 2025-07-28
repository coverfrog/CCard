namespace Cf.CCard
{
    public interface ICardDeck
    {
        void Shuffle();
        
        void Stack(CardData cardData);
        
        bool Draw(out CardData cardData);
    }
}