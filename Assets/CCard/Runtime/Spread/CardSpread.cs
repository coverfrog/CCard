using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    public abstract class CardSpread : ScriptableObject, ICardSpread
    {
        public abstract void Spread(bool isMine, List<ICard> cardList);
    }
}
