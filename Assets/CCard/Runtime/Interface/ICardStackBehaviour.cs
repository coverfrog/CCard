using System;
using System.Collections.Generic;

namespace Cf.CCard
{
    public interface ICardStackBehaviour
    {
        void Stack(IReadOnlyList<CardData> cardDataList, Action<List<ICard>> onEnd);
    }
}