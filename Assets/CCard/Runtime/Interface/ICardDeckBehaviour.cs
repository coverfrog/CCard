using System;

namespace Cf.CCard
{
    public interface ICardDeckBehaviour
    {
        bool IsInitialized { get; }
        
        void Initialize();

        void Stack();

        bool Get(out ICard card);
        
        void Report();
    }
}