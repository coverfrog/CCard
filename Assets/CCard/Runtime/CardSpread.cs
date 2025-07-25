using System;
using UnityEngine;

namespace Cf.CCard
{
    public class CardSpread : MonoBehaviour
    {
        [SerializeField] private Transform parentTr;
        [Space]
        [SerializeField] private float radius = 2.0f;
        [SerializeField] private float maxAngle = 45.0f;

        private void Update()
        {
            Spread();
        }

        public void Spread()
        {
            parentTr ??= transform;
            
            const float tau = Mathf.PI * 2;
            
            int childCount = parentTr.childCount;   
            
            float interval = 1.0f / (childCount - 1);
            float max = tau * (maxAngle / 360.0f);

            parentTr.localEulerAngles = new Vector3(
                parentTr.localEulerAngles.x, 
                max * -0.5f * Mathf.Rad2Deg, 
                parentTr.localEulerAngles.z);
            
            for (int i = 0; i < childCount; i++)
            {
                float a =  max * interval * i;
                
                float x = Mathf.Cos(a);
                float z = Mathf.Sin(a);

                float atan = Mathf.Atan2(x, z);
                float y = atan * Mathf.Rad2Deg;
                
                Transform tr = parentTr.GetChild(i);

                tr.localPosition = new Vector3(
                    x * radius,
                    tr.localPosition.y,
                    z * radius);
                
                tr.localEulerAngles = new Vector3(
                    tr.localEulerAngles.x,
                    y, 
                    tr.localEulerAngles.z);
            }
        }

        [ContextMenu("[Context] Spread")]
        public void SpreadContext()
        {
            Spread();

#if UNITY_EDITOR
            UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
#endif
        }
    }
}
