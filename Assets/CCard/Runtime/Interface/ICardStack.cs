using System;
using System.Collections.Generic;

namespace Cf.CCard
{
    public interface ICardStack
    {
        void Stack(ICard card, int current, Action<int> onComplete);
    }
}