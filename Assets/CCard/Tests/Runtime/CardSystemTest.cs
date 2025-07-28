using System;
using UnityEngine;

namespace Cf.CCard.Tests
{
    public class CardSystemTest : MonoBehaviour
    {
        private CardDeck _mCardDeck;
        private CardSpawner _mCardSpawner;

        private void Start()
        {
            _mCardDeck = FindAnyObjectByType<CardDeck>();
            _mCardDeck.Init(() =>
            {
                
            });
            
            _mCardSpawner = FindAnyObjectByType<CardSpawner>();
            _mCardSpawner.Init(() =>
            {
                
            });
        }
    }
}
