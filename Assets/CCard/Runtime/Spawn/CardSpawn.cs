using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Cf.CCard
{
    public class CardSpawn : ICardSpawn
    {
        public IObjectPool<ICard> Pool { get; }

        private readonly Func<ICard> _mCreateFunc;
        
        public CardSpawn(Func<ICard> createFunc, bool collectionCheck = true, int defaultCapacity = 10, int maxSize = 10000)
        {
            if (ReferenceEquals(createFunc, null))
            {
                Debug.Assert(false, "Card Builder Is Null");
            }

            _mCreateFunc = createFunc;
            
            Pool = new ObjectPool<ICard>(
                OnCreate,
                OnGet,
                OnRelease,
                OnDestroy,
                collectionCheck,
                defaultCapacity, 
                maxSize);
        }

        public ICard Get()
        {
            Pool.Get(out ICard card);

            return card;
        }

        public ICard OnCreate()
        {
            return _mCreateFunc();
        }
        
        public void OnGet(ICard card)
        {
           
        }
        
        public void OnRelease(ICard card)
        {
           
        }
        
        public void OnDestroy(ICard card)
        {
            
        }
    }
}
