using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CollectibleSystem : MonoBehaviour
{
    public int Coin;
    public GameManager GM;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent <AudioManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            audioManager.PlaySFX(audioManager.coinCollect);
            Destroy(other.gameObject);
            Coin++;
            GM.UpdateCoinText(Coin);
        }
    }
}
