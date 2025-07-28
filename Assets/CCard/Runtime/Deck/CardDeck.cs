using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    public class CardDeck : ICardDeck
    {
        private readonly List<CardData> _mCardDataList = new();

        public IReadOnlyList<CardData> CardDataList => _mCardDataList;
        
        public CardDeck()
        {
            
        }
        
        public CardDeck(CardDeckData data, bool isShuffle)
        {
            if (!data)
            {
                return;
            }

            foreach (CardDeckData.Option option in data.OptionList)
            {
                for (int i = 0; i < option.count; i++)
                {
                    _mCardDataList.Add(option.data);
                }
            }

            if (!isShuffle)
            {
                return;
            }

            Shuffle();
        }

        public void Shuffle()
        {
            if (ReferenceEquals(_mCardDataList, null))
            {
                return;
            }
            
            int count = _mCardDataList.Count;
            var temp = new List<CardData>(count);
            int[] indexes = Enumerable.Range(0, count).ToArray();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    int r = Random.Range(0, count);

                    (indexes[j], indexes[r]) = (indexes[r], indexes[j]);
                }
            }

            for (int i = 0; i < count; i++)
            {
                temp.Add(_mCardDataList[indexes[i]]);
            }
            
            _mCardDataList.Clear();
            _mCardDataList.AddRange(temp);
        }

        public void Stack(CardData cardData)
        {
            _mCardDataList.Add(cardData);
        }

        public void Report()
        {
            string msg = "--- Card Deck ---\n";
            int count = _mCardDataList.Count;
            
            for (int i = 0; i < count; i++)
            {
                msg += $"[ {i} ] {_mCardDataList[i].DisplayName}\n";
            }
            
            Debug.Log(msg);
        }
    }
}
