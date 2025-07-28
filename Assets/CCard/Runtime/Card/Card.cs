using DG.Tweening;
using UnityEngine;

namespace Cf.CCard
{
    public class Card : MonoBehaviour, ICard
    {
        [Header("Debug View")]
        [SerializeField] private CardTransformData transformData;

        public void TranslateTo(CardTransformData data, float dur, bool isScale)
        {
            transformData = data;
            
            transform.DOMove(data.position, dur);
            transform.DORotateQuaternion(data.rotation, dur);

            if (!isScale)
            {
                return;
            }
            
            transform.DOScale(data.scale, dur);
        }
    }
}
