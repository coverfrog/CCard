using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    public class CardSpreadSample : MonoBehaviour
    {
        [SerializeField] private CardSpread spread;
        [Space]
        [SerializeField] private Card prefab;
        [SerializeField] private List<Card> cardList = new List<Card>();
        
        private void Update()
        {
            return;
            
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
        }

        private void Spread()
        {
            var list = spread.Spread(transform, false, cardList.Count);

            for (int i = 0; i < cardList.Count; i++)
            {
                cardList[i].TranslateTo(list[i], spread.Duration, true);
            }
        }
    }
}