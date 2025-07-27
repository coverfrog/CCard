using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    [CreateAssetMenu(menuName = "Cf/CCard/Spread/Circle", fileName = "Circle")]
    public class CardSpreadCircle : CardSpread
    {
        #region Option

        [Serializable]
        public class Option
        {
            [SerializeField] private float mMaxAngleDeg;
            [SerializeField] private float mWidth = 1.0f;
            [SerializeField] private float mHeight = 1.0f;
            
            public float MaxAngleDeg => mMaxAngleDeg;
            public float Width => mWidth;
            public float Height => mHeight;
        }

        #endregion

        [SerializeField] private List<Option> mOptionList = new List<Option>();

        #region Get

        public IReadOnlyList<Option> OptionList => mOptionList;

        #endregion
        
        public override ICardSpread Clone()
        {
            var ins = CreateInstance<CardSpreadCircle>();
            ins.mDuration = mDuration;
            ins.mInitScale = mInitScale;
            ins.mOptionList = mOptionList;

            return ins;
        }

        public override List<CardTransformData> Spread(Transform origin, bool isLocal, int count)
        {
            Option option = count >= mOptionList.Count ? mOptionList[^1] : mOptionList[count - 1];
            Vector3 center = isLocal ? origin.localPosition : origin.position;
            
            float interval = 1.0f / (count - 1);
            float maxAngleRad = 
                Mathf.PI * 2.0f *               // tau
                option.MaxAngleDeg / 360.0f;    // max angle deg -> rad
            
            var result = new List<CardTransformData>();

            for (int i = 0; i < count; i++)
            {
                float percent = count > 1 ? i * interval : 0.5f;
                
                float angleRad = -maxAngleRad * 0.5f +      // min left
                                 maxAngleRad * percent ;    // add interval    
                
                float x = Mathf.Lerp(
                    -option.Width * 0.5f,   // left 
                    +option.Width * 0.5f,   // right
                    percent);             // move to interval
                
                float z = Mathf.Sin(Mathf.PI * percent) * option.Height; // height to sin

                var data = new CardTransformData()
                {
                    position = center + new Vector3(x, 0, z),
                    rotation = Quaternion.Euler(0, angleRad * Mathf.Rad2Deg, 0),
                    scale = mInitScale
                };
                
                result.Add(data);
            }

            return result;
        }
    }
}
