using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    public class CardHandGroup : MonoBehaviour
    {
        [SerializeField] private List<CardHand> mCardHandList = new List<CardHand>();

        public void Init(Action onComplete)
        {
            StartCoroutine(CoInit(onComplete));
        }

        private IEnumerator CoInit(Action onComplete)
        {
            yield return null;
        }
        
        public void AddHand(bool isMine, ulong id)
        {
            
        }
    }
}
