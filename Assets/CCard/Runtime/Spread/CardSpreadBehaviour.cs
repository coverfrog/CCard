using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    public class CardSpreadBehaviour : MonoBehaviour, ICardSpreadBehaviour
    {
        [Header("[ Func ]")]
        [SerializeField] private CardSpread mCardSpread;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            
        }

        public void Spread(List<ICard> cardList)
        {
            mCardSpread?.Spread(cardList);
        }
    }
}
