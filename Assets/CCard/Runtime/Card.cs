using DG.Tweening;
using UnityEngine;

namespace Cf.CCard
{
    public class Card : MonoBehaviour
    {
        public Prs originPrs;

        public void Move(Prs prs, float dur)
        {
            transform.DOMove(prs.position, dur);
            transform.DORotateQuaternion(prs.rotation, dur);
            transform.DOScale(prs.scale, dur);
        }
    }
}
