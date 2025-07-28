using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    [CreateAssetMenu(menuName = "Cf/CCard/Deck/Data", fileName = "DeckData")]
    public class CardDeckData : ScriptableObject
    {
        [Serializable]
        public class Option
        {
            [SerializeField] private CardData mData;
            [SerializeField] private uint mCount = 1;
            
            public CardData Data => mData;
            public uint Count => mCount;
        }

        [SerializeField] private List<Option> mOptionList = new List<Option>();
        
        public IReadOnlyList<Option> OptionList => mOptionList;
        
        public CardDeckData Clone()
        {
            var ins = CreateInstance<CardDeckData>();
            ins.mOptionList = mOptionList;

            return ins;
        }
    }
}
