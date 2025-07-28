using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    [CreateAssetMenu(fileName = "Card Deck", menuName = "Cf/CCard/Deck")]
    public class CardDeckData : ScriptableObject
    {
        [Serializable]
        public class Option
        {
            public CardData data;
            public int count;
        }
        
        [SerializeField] private List<Option> optionList = new List<Option>();
        
        public IReadOnlyList<Option> OptionList => optionList;
    }
}