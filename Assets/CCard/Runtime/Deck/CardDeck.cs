using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Random = UnityEngine.Random;

namespace Cf.CCard
{
    public class CardDeck : MonoBehaviour
    {
        [Header("Init")] 
        [SerializeField] private bool mInitShuffle = true;
        [SerializeField][Min(1)] private int mShuffleCount = 2;
        [SerializeField] private float mSpawnDelay = 0.01f;
        [SerializeField] private CardDeckData mInitCardDeckData;
        
        [Header("References")]
        [SerializeField] private CardSpawner mCardSpawner;
        
        [Header("Func")]
        [SerializeField] private CardStack mCardStackFunc;
        
        [Header("Debug View")]
        [SerializeField] private List<CardData> mCardDataList = new List<CardData>();
        
        private Stack<Card> _mCardsStack = new Stack<Card>();

        public void Init(Action onComplete)
        {
            if (!mInitCardDeckData)
            {
#if UNITY_EDITOR
                Debug.Assert(false, "CardDeckData is not set");
#endif    
                return;
            }

            if (!mCardSpawner)
            {
#if UNITY_EDITOR
                Debug.Assert(false, "CardDeckData is not set");
#endif
                return;
            }
            
            StartCoroutine(CoInit(onComplete));
        }

        private IEnumerator CoInit(Action onComplete)
        {
            // option
            var optionList = mInitCardDeckData.Clone().OptionList;
            
            // copy
            var cardDataList = new List<CardData>(optionList.Count);
            foreach (CardDeckData.Option option in optionList)
            {
                for (int i = 0; i < option.Count; i++)
                {
                    cardDataList.Add(option.Data);
                }
            }
            
            // value
            mCardDataList.Clear();
            mCardDataList.AddRange(cardDataList);
            
            // shuffle
            if (!mInitShuffle)
            {
                yield break;
            }
            
            // rand index
            int count = cardDataList.Count;
            int[] indexes = Enumerable.Range(0, count).ToArray();

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    int randIndex = Random.Range(0, count);

                    (indexes[j], indexes[randIndex]) = (indexes[randIndex], indexes[j]);
                }
            }
            
            // spawn
            mCardDataList.Clear();
            for (int i = 0; i < count; i++)
            {
                CardData data = cardDataList[indexes[i]];
                
                mCardDataList.Add(data);
                
                mCardSpawner.Get(out ICard card);
                
                // var builder = new CardBuilder();
                //
                // card.Init(data);
            }
            
            yield return null;
        }
        
        public void Stack(Card card)
        {
            mCardStackFunc.Stack();
            
            _mCardsStack.Push(card);
        }
    }
}