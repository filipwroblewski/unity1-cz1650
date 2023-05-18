using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    int coins = 0;

    [SerializeField] Text textField;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++; // coins = coins + 1; || coins += 1;
            Debug.Log($"Monety: {coins}");

            textField.text = $"Monety: {coins}";
        }
    }

}
