using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Cf.CCard
{
    [CreateAssetMenu(fileName = "Rectangle", menuName = "Cf/CCard/Spread/Rectangle")]
    
    public class CardSpreadRectangle : CardSpread
    {
        [SerializeField] private float mRadius= 1.5f;
        [SerializeField] private float mDuration = 0.5f;
            
        public override void Spread(List<ICard> cardList)
        {
            int count = cardList.Count;

            if (count == 0)
            {
                return;
            }

            float interval = 1.0f / (count - 1);
            
            for (int i = 0; i < count; i++)
            {
                float t = count == 1 ? 0.5f : i * interval;
                
                float x = Mathf.Lerp(-mRadius, +mRadius, t);

                cardList[i].Tr.DOLocalMove(new Vector3(x, 0, 0), mDuration);
            }
        }
    }
}