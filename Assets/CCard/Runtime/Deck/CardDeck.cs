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
        [Header("Func")]
        [SerializeField] private CardStack mCardStackFunc;
        
        private Stack<Card> _mCardsStack = new Stack<Card>();

        public void Stack(Card card)
        {
            mCardStackFunc.Stack();
            
            _mCardsStack.Push(card);
        }
    }
}