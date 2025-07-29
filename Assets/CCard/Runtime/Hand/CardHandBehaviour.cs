using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Cf.CCard
{
    [RequireComponent(typeof(CardSpreadBehaviour))]
    public class CardHandBehaviour : MonoBehaviour, ICardHandBehaviour
    {
        [Header("[ Flag ]")] 
        [SerializeField] private bool mIsMine;
        
        [Header("[ References ]")]
        [SerializeField] private CardDeckBehaviour mDeckBehaviour;
        [SerializeField] private CardSpreadBehaviour mSpreadBehaviour;
        
        private CardSpread _mCardSpread;
        private List<ICard> _mCardList;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            _mCardList = new List<ICard>();
            
            Debug.Assert(mDeckBehaviour != null, "Deck Behaviour is null");
            Debug.Assert(mSpreadBehaviour != null, "Spread Behaviour is null");
            
            mDeckBehaviour.OnStackEnd += FirstDraw;
            
        }

        private void FirstDraw()
        {
            const int target = 4;

            int count = 0;
            
            for (int i = 0; i < target; i++)
            {
                if (!mDeckBehaviour.Get(out ICard card))
                {
                    continue;
                }
                
                _mCardList.Add(card);
                
                card.Tr.SetParent(transform);
                card.Tr
                    .DOLocalMove(Vector3.zero, 0.5f)
                    .OnComplete(() =>
                    {
                        ++count;

                        if (count != target)
                        {
                            return;
                        }
                        
                        Spread();
                    });
            }
        }

        [ContextMenu("> Spread")]
        public void Spread()
        {
            mSpreadBehaviour?.Spread(mIsMine, _mCardList);
        }
    }
}
