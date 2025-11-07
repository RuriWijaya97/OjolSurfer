using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CollectibleSystem : MonoBehaviour
{
    public int Coin;
    public GameManager GM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            Coin++;
            GM.UpdateCoinText(Coin);
        }
    }
}
