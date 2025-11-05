using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectibleSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ambil Koin");
        }
    }
}
