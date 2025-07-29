using System.Collections.Generic;

namespace Cf.CCard
{
    public interface ICardSpread
    {
        void Spread(bool isMine, List<ICard> cardList);
    }
}