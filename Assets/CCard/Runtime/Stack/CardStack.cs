using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    public abstract class CardStack : ScriptableObject, ICardStack
    {
        public abstract void Stack(ICard card, int current, Action<int> onComplete);
    }
}
