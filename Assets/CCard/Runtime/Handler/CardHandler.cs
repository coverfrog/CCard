using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    public class CardHandler : MonoBehaviour
    {
        [SerializeField] private CardHandGroup mHandGroup;
        [SerializeField] private CardDeckGroup mDeckGroup;

        public void Init(Action onComplete)
        {
            StartCoroutine(CoInit(onComplete));
        }

        private IEnumerator CoInit(Action onComplete)
        {
            const int initTarget = 2;
            
            int initCount = 0;
            
            mHandGroup.Init(() =>
            {
                ++initCount;
            });
            
            mDeckGroup.Init(() =>
            {
                ++initCount;
            });

            while (initCount < initTarget)
            {
                yield return null;
            }
            
            onComplete?.Invoke();
        }
    }
}