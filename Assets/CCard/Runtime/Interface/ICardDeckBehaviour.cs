namespace Cf.CCard
{
    public interface ICardDeckBehaviour
    {
        void Initialize();

        void Stack();

        bool Get(out ICard card);
        
        void Report();
    }
}