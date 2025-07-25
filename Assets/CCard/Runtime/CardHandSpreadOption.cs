using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    [CreateAssetMenu(menuName = "Cf/CCard/Hand/Spread", fileName = "Spread Option")]
    public class CardHandSpreadOption : ScriptableObject
    {
        [Serializable]
        public class Max
        {
            [SerializeField] private float angleDeg = 90.0f;
            [SerializeField] private float width = 1.0f;
            [SerializeField] private float height = 1.0f;
            
            public float AngleDeg => angleDeg;
            public float Width => width;
            public float Height => height;
        }
        
        [Header("float")]
        [SerializeField] private float spreadDuration = 0.5f;
        
        public float SpreadDuration => spreadDuration;
        
        [Header("data")]
        [SerializeField] private List<Max> dataList = new List<Max>();
        
        public List<Max> DataList => dataList;
    }
}