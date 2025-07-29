using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Cf.CCard
{
    [CreateAssetMenu(fileName = "Circle", menuName = "Cf/CCard/Spread/Circle")]
    public class CardSpreadCircle : CardSpread
    {
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
        
        [Serializable]
        public class Result
        {
            [SerializeField] private Vector3 mPosition;
            [SerializeField] private Quaternion mRotation;

            public Result(Vector3 position, Quaternion rotation)
            {
                mPosition = position;
                mRotation = rotation;
            }
            
            public Vector3 Position => mPosition;
            public Quaternion Rotation => mRotation;
        }
        
        [Header("Rect")]
        [SerializeField] private List<Option> mOptionList = new List<Option>();

        [Header("Time")]
        [SerializeField] private float mDuration = 0.5f;
        
        public override void Spread(bool isMine, List<ICard> cardList)
        {
            Debug.Assert(mOptionList.Count > 0, "Option list is empty");
            
            int count = cardList.Count;
            
            Option option = count >= mOptionList.Count ? mOptionList[^1] : mOptionList[count - 1];
            Vector3 center = Vector3.zero;
            
            float interval = 1.0f / (count - 1);
            float maxAngleRad = 
                Mathf.PI * 2.0f *               // tau
                option.MaxAngleDeg / 360.0f;    // max angle deg -> rad
            
            var results = new Result[count];
            
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

                Vector3 position = center + new Vector3(x, 0, z);
                Quaternion rotation = Quaternion.Euler(0, angleRad * Mathf.Rad2Deg, 0);
                
                var result = new Result(position, rotation);
                results[i] = result;
            }

            for (int i = 0; i < count; i++)
            {
                Transform tr = cardList[i].Tr;
                Result result = results[i];
                
                tr.DOLocalMove(result.Position, mDuration);
                tr.DORotateQuaternion(result.Rotation, mDuration);
            }
        }
    }
}