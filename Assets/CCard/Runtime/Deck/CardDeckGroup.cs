using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Cf.CCard
{
    public class CardDeckGroup : MonoBehaviour
    {
        [SerializeField] private AssetReference mDeckReference;
        [Space]
        [SerializeField] private CardDeck mDeckPrefab;
        [SerializeField] private List<CardDeck> mDeckList = new List<CardDeck>();
        
        public void Init(Action onComplete)
        {
            StartCoroutine(CoInit(onComplete));
        }

        private IEnumerator CoInit(Action onComplete)
        {
            const int initTarget = 1;
            
            int initCount = 0;

            InitPrefab(() =>
            {
                ++initCount;
            });
            
            while (initCount < initTarget)
            {
                yield return null;
            }
            
            onComplete?.Invoke();
        }
        
        private void InitPrefab(Action onComplete)
        {
            bool isExist = mDeckReference != null && mDeckReference.RuntimeKeyIsValid();

            if (!isExist)
            {
#if UNITY_EDITOR
                Debug.Assert(false,"Hand Reference Not Found");
#endif
                return;
            }
            
            Addressables.LoadAssetAsync<GameObject>(mDeckReference).Completed += op =>
            {
                if (op.Status != AsyncOperationStatus.Succeeded)
                {
#if UNITY_EDITOR
                    Debug.Assert(false,"Hand Reference Not Found");    
#endif
                    return;
                }

                if (op.Result.TryGetComponent(out mDeckPrefab))
                {
                    onComplete?.Invoke();
                }

                else
                {
#if UNITY_EDITOR
                    Debug.Assert(false,"Hand Reference Not Found");
#endif
                }
            };
        }
    }
}