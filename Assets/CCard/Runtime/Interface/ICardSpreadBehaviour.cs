using System.Collections.Generic;

namespace Cf.CCard
{
    public interface ICardSpreadBehaviour
    {
        void Initialize();
        
        void Spread(bool isMine, List<ICard> cardList);
    }
}