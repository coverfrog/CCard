using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    public abstract class CardSpread : ScriptableObject, ICardSpread
    {
        [SerializeField] protected float mDuration = 0.2f;
        [SerializeField] protected Vector3 mInitScale = Vector3.one;

        #region Get

        public float Duration => mDuration;
        
        public Vector3 InitScale => mInitScale;

        #endregion
        
        public abstract ICardSpread Clone();

        public abstract List<CardTransformData> Spread(Transform origin, bool isLocal, int count);
    }
}
