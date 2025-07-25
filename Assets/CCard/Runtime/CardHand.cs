using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    public class CardHand : MonoBehaviour
    {
        [Header("Prefab")] 
        [SerializeField] private Card prefab;
        
        [Header("Card")] 
        [SerializeField] private List<Card> cardList = new List<Card>();

        [Header("Spread")] 
        [SerializeField] private int focusIndex = -1;
        [SerializeField] private CardHandSpreadOption spreadOption;

        private const float Tau = Mathf.PI * 2.0f;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Card card = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                card.gameObject.SetActive(true);
                
                cardList.Add(card);
                
                Spread();
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Destroy(cardList[^1].gameObject);
                cardList.RemoveAt(cardList.Count - 1);
                
                Spread();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Spread();
            }
            
            Focus();
        }

        private void Spread()
        {
            var count = cardList.Count;
            var maxOption = count >= spreadOption.DataList.Count ?
                spreadOption.DataList[^1] :
                spreadOption.DataList[count - 1];
            
            float interval = 1.0f / (count - 1);
            float maxAngleRad = Tau * maxOption.AngleDeg / 360.0f;
            
            var prsList = new List<Prs>(count);
         
            
            for (int i = 0; i < count; i++)
            {
                float percent = count > 1 ? i * interval : 0.5f;
                
                float angleRad = -maxAngleRad * 0.5f + maxAngleRad * percent ;
                
                float x = Mathf.Lerp(-maxOption.Width * 0.5f, +maxOption.Width * 0.5f, percent);
                
                float z = Mathf.Sin(Mathf.PI * percent) * maxOption.Height;

                Prs prs = new Prs()
                {
                    position = new Vector3(x, 0, z),
                    rotation = Quaternion.Euler(0, angleRad * Mathf.Rad2Deg, 0),
                    scale = prefab.transform.localScale,
                    
                };
                
                prsList.Add(prs);
            }
            
            
            for (int i = 0; i < count; i++)
            {
                Card card = cardList[i];

                card.originPrs = prsList[i];
                card.Move(card.originPrs, 0.7f);
            }
        }

        private void Focus()
        {
            if (focusIndex < 0)
            {
                return;
            }
        }
    }
}
