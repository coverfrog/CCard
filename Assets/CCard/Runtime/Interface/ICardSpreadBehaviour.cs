using System.Collections.Generic;

namespace Cf.CCard
{
    public interface ICardSpreadBehaviour
    {
        void Initialize();
        
        void Spread(List<ICard> cardList);
    }
}