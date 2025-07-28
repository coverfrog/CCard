using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Pool;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Cf.CCard
{
    public class CardSpawner : MonoBehaviour
    {
        [Header("Pool")] 
        [SerializeField] private bool mIsCollectionCheck = true;
        [SerializeField] private int mDefaultCapacity = 50;
        [SerializeField] private int mMaxSize = 10000;
        
        [Header("Addressable")]
        [SerializeField] private AssetReference mCardReference;
        
        [Header("Debug View")]
        [SerializeField] private Card mCardPrefab;
        
        private IObjectPool<ICard> _mCardPool;
        
        public void Init(Action onComplete)
        {
            StartCoroutine(CoInit(onComplete));
        }

        private IEnumerator CoInit(Action onComplete)
        {
            const int initTarget = 2;

            int initCount = 0;

            InitPrefab(() =>
            {
                ++initCount;
            });
            
            InitPool(() =>
            {
                ++initCount;
            });
            
            while (initCount < initTarget) yield return null;
            
            onComplete?.Invoke();
        }

        private void InitPrefab(Action onComplete)
        {
            bool isExist = mCardReference != null && mCardReference.RuntimeKeyIsValid();

            if (!isExist)
            {
#if UNITY_EDITOR
                Debug.Assert(false, "CardReference is not valid");
#endif
                return;
            }

            Addressables.LoadAssetAsync<GameObject>(mCardReference).Completed += op =>
            {
                if (op.Status != AsyncOperationStatus.Succeeded)
                {
#if UNITY_EDITOR
                    Debug.Assert(false, "CardReference is not valid");
#endif
                    return;
                }

                if (op.Result.TryGetComponent(out mCardPrefab))
                {
                    onComplete?.Invoke();
                }

                else
                {
#if UNITY_EDITOR
                    Debug.Assert(false, "CardReference is not valid");
#endif
                }
            };
        }

        private void InitPool(Action onComplete)
        {
            if (_mCardPool != null)
            {
                onComplete?.Invoke();
                return;
            }

            _mCardPool = new ObjectPool<ICard>(
                PoolOnCreate, 
                PoolOnGet, 
                PoolOnRelease,
                PoolOnDestroy,
                mIsCollectionCheck,
                mDefaultCapacity,
                mMaxSize);
            
            onComplete?.Invoke();
        }
        
        private ICard PoolOnCreate()
        {
            throw new NotImplementedException();
        }

        private void PoolOnGet(ICard obj)
        {
            throw new NotImplementedException();
        }
        
        private void PoolOnRelease(ICard obj)
        {
            throw new NotImplementedException();
        }
        
        private void PoolOnDestroy(ICard obj)
        {
            throw new NotImplementedException();
        }

        public void Get(out ICard card)
        {
            if (_mCardPool == null)
            {
#if UNITY_EDITOR
                Debug.Assert(false, "CardReference is not valid");
#endif
                card = null;
                
                return;
            }

            _mCardPool.Get(out card);
        }
    }
}