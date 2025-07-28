using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Cf.CCard
{
    [CreateAssetMenu(fileName = "Top Down", menuName = "Cf/CCard/Stack/Top Down")]
    public class CardStackTopDown : CardStack
    {
        [Header("[ Flag ]")] 
        [SerializeField] private bool mIsOverlap;
        
        [Header("[ Height ]")]
        [SerializeField] private float mBeginHeight = 1.0f;
        [SerializeField] private float mEndHeight;
        [SerializeField] private float mUnitHeight = 0.05f;
        
        [Header("[ Time ]")]
        [SerializeField] private float mDuration = 0.5f;
        [SerializeField] private float mDelay = 0.5f;

        /*
         * [ Recommend Time Setting ]
         * mDelay = mDuration * 0.5f
         */
        
        public override void Stack(ICard card, int current, Action<int> onComplete)
        {
            card.Tr.localPosition = Vector3.up * mBeginHeight;
            card.Tr.gameObject.SetActive(false);
            
            float delay = mDelay * current;
            float endHeight = mIsOverlap ? mEndHeight : mUnitHeight * current;
            
            card.Tr
                .DOLocalMoveY(endHeight, mDuration)
                .SetEase(Ease.OutExpo)
                .SetDelay(delay)
                .OnStart(() =>
                {
                    card.Tr.gameObject.SetActive(true);
                }).
                OnComplete(() =>
                {
                    onComplete?.Invoke(current);
                });
        }
    }
}