using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Cf.CCard
{
    public class CardHandGroup : MonoBehaviour
    {
        [SerializeField] private AssetReference mHandReference;
        [Space]
        [SerializeField] private CardHand mHandPrefab;
        [SerializeField] private List<CardHand> mCardHandList = new List<CardHand>();

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
        }

        private void InitPrefab(Action onComplete)
        {
            bool isExist = mHandReference != null && mHandReference.RuntimeKeyIsValid();

            if (!isExist)
            {
#if UNITY_EDITOR
                Debug.Assert(false,"Hand Reference Not Found");
#endif
                return;
            }
            
            Addressables.LoadAssetAsync<GameObject>(mHandReference).Completed += op =>
            {
                if (op.Status != AsyncOperationStatus.Succeeded)
                {
#if UNITY_EDITOR
                    Debug.Assert(false,"Hand Reference Not Found");    
#endif
                    return;
                }

                if (op.Result.TryGetComponent(out mHandPrefab))
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

        public void AddHand(bool isMine, ulong id)
        {
            
        }
    }
}
