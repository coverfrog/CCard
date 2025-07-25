using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    public class CardDeck : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] private Card prefab;
        [SerializeField] private List<Card> cardList = new List<Card>();
        
        [Header("Init")]
        [SerializeField] private int initCount = 38;
        [SerializeField] private float initDelay = 0.05f;
        
        private IEnumerator Start()
        {
            for (int i = 0; i < initCount; i++)
            {
                Card card = Instantiate(prefab, transform.position + Vector3.back * 3.0f, Quaternion.identity);
                card.gameObject.SetActive(true);
                card.Move(new Prs()
                {
                    position = transform.position,
                    scale = prefab.transform.localScale,
                    rotation = prefab.transform.rotation,
                }, initDelay);
                
                
                yield return new WaitForSeconds(initDelay);
            }
        }
    }
}
