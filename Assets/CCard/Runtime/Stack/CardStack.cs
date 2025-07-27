using UnityEngine;

namespace Cf.CCard
{
    public abstract class CardStack : ScriptableObject, ICardStack
    {
        public abstract ICardStack Clone();
        
        public abstract Card Stack();
    }
}