using UnityEngine;

namespace Cf.CCard
{
    public abstract class Card : MonoBehaviour, ICard
    {
        public Transform Tr => transform;
        
        public abstract void Initialize(CardData data);
    }
}
