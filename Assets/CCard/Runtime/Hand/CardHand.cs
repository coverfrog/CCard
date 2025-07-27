using UnityEngine;

namespace Cf.CCard
{
    public class CardHand : MonoBehaviour
    {
        [SerializeField] private bool mIsMine;
        [SerializeField] private ulong mId;

        public void Init(bool isMine, ulong id)
        {
            mIsMine = isMine;
            mId = id;
        }
    }
}
