using UnityEngine;

namespace Cf.CCard
{
    public interface ICard
    {
        Transform Tr { get; }
        
        void Initialize(CardData data);
    }
}
