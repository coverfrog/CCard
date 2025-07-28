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
            });
        }

        [ContextMenu("> Report")]
        public void Report()
        {
            _mCardDeck?.Report();
        }
    }
}
