using UnityEngine;

namespace Cf.CCard
{
    [CreateAssetMenu(menuName = "Cf/CCard/Stack/Simple", fileName = "Simple")]
    public sealed class CardStackSimple : CardStack
    {
        public override ICardStack Clone()
        {
            var ins = CreateInstance<CardStackSimple>();
            
            return ins;
        }

        public override Card Stack()
        {
            throw new System.NotImplementedException();
        }
    }
}