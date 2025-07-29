using System;
using UnityEngine;

namespace Cf.CCard
{
    public class CardSpawnBehaviour : MonoBehaviour, ICardSpawnBehaviour
    {
        [Header("[ Pool ]")]
        [SerializeField] private Card mCard;
        [SerializeField] private bool mCollectionCheck = true;
        [SerializeField] private int mDefaultCapacity = 40;
        [SerializeField] private int mMaxSize = 10000;
        
        private CardSpawn _mCardSpawn;

        public bool IsInitialized { get; private set; }

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            Debug.Assert(mCard != null, "Card Prefab Is Null");
            
            _mCardSpawn = new CardSpawn(
                Create,
                mCollectionCheck,
                mDefaultCapacity,
                mMaxSize);

            IsInitialized = true;
        }

        private ICard Create()
        {
            return Instantiate(mCard, transform);
        }

        public ICard Get()
        {
            return _mCardSpawn?.Get();
        }
    }
}
