using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Cf.CCard
{
    public class CardDeck : MonoBehaviour
    {
        [SerializeField] private AssetReference mCardReference;
        [Space]
        [SerializeField] private Card mCardPrefab;
        [SerializeField] private List<Card> mCardsList = new List<Card>();

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
                initCount++;
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
    }
}