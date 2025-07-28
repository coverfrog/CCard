using UnityEngine;

namespace Cf.CCard
{
    public class CardSimple : Card
    {
        public override void Initialize(CardData data)
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
