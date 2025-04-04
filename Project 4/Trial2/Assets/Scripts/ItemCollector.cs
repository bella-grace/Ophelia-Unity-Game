using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int count = 0;

    [SerializeField] private Text flowersText;
    [SerializeField] private Text score;

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Flower"))
        {
            Destroy(collision.gameObject);
            count++;
            Debug.Log("Flowers: " + count);
            flowersText.text = "Flowers: " + count;
            score.text = "Flowers: " + count;
        }
    }
}
