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
        [SerializeField] private float mDurationSpread = 0.5f;
        [SerializeField] private float mDurationFlip = 0.5f;
            
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

                Sequence seq = DOTween.Sequence();
                
                seq.Append( cardList[i].Tr.DOLocalMove(new Vector3(x, 0, 0), mDurationSpread));
                seq.Append( cardList[i].Tr.DORotate(new Vector3(0, -0, 0), mDurationFlip));
            }
        }
    }
}