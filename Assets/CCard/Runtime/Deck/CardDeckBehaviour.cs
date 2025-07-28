using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    [RequireComponent(typeof(CardStackBehaviour))]
    public class CardDeckBehaviour : MonoBehaviour, ICardDeckBehaviour
    {
        [Header("[ References ]")] 
        [SerializeField] private CardStackBehaviour mStackBehaviour;
        
        [Header("[ Init ]")]
        [SerializeField] private CardDeckData mInitCardDeckData;

        private CardDeck _mCardDeck;
        private List<ICard> _mCardList;

        private IReadOnlyList<CardData> CardDataList => _mCardDeck?.CardDataList;

        public event Action OnStackEnd;
        
        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            _mCardDeck = new CardDeck(mInitCardDeckData, true);
        }

        [ContextMenu("> Stack")]
        public void Stack()
        {
            mStackBehaviour?.Stack(CardDataList, cardList =>
            {
#if true
                Debug.Log("[ Card Stack ] Complete");
#endif
                _mCardList = cardList;
                
                OnStackEnd?.Invoke();
            });
        }

        public bool Get(out ICard card)
        {
            if (_mCardList.Count == 0)
            {
                card = null;
                return false;
            }

            card = _mCardList[^1];
            _mCardList.RemoveAt(_mCardList.Count - 1);

#if true
            Debug.Log($"[ Card Deck ] Remain At : {_mCardList.Count}");
#endif
            
            return true;
        }
        
        [ContextMenu("> Report")]
        public void Report()
        {
            _mCardDeck?.Report();
        }
    }
}
