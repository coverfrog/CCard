using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    public class CardStackSample : MonoBehaviour
    {
        [SerializeField] private CardStack mStackFunc;
        [Space]
        [SerializeField] private Card mPrefab;
        
        private Stack<Card> _mStack;

        public void Init()
        {
            _mStack = new Stack<Card>();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Stack();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                
            }
        }

        private void Stack()
        {
            Card card = mStackFunc.Stack();
            
            _mStack.Push(card);
        }
    }
}