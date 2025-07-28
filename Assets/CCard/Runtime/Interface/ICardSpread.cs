using System.Collections.Generic;

namespace Cf.CCard
{
    public interface ICardSpread
    {
        void Spread(List<ICard> cardList);
    }
}