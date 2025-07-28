using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Cf.CCard
{
    public class CardStackBehaviour : MonoBehaviour, ICardStackBehaviour
    {
        [Header("[ References ]")] 
        [SerializeField] private CardSpawnBehaviour mSpawnBehaviour;
        
        [Header("[ Func ]")]
        [SerializeField] private CardStack mCardStackFunc;

        private int _mStackCurrent;
        private int _mStackTotal;

        private List<ICard> _mCardList;
        private Action<List<ICard>> _mOnEnd;
        
        private void Stack(CardData cardData)
        {
            Debug.Assert(mSpawnBehaviour != null, "Spawn Behaviour is null");
            Debug.Assert(mCardStackFunc != null, "Card Stack Func is null");
            
            ICard card = mSpawnBehaviour.Get();
            card.Tr.SetParent(transform);
            card.Initialize(cardData);
            
            _mCardList.Add(card);
            
            mCardStackFunc?.Stack(card, _mStackCurrent, current =>
            {
#if false
                Debug.Log($"[ Card Stack ][ {current + 1} / {_mStackTotal} ][ {(current + 1) /(float)_mStackTotal * 100.0f:F1}% ]");
#endif

                if (current + 1 < _mStackTotal) return;
                
                _mOnEnd?.Invoke(_mCardList);
                _mCardList.Clear();
            });
        }

        public void Stack(IReadOnlyList<CardData> cardDataList, Action<List<ICard>> onEnd)
        {
            _mOnEnd = onEnd;
            _mStackTotal = cardDataList.Count;
            
            _mStackCurrent = 0;
            _mCardList = new List<ICard>(_mStackTotal);
            
            foreach (CardData cardData in cardDataList)
            {
                Stack(cardData);

                ++_mStackCurrent;
            }
        }
    }
}
