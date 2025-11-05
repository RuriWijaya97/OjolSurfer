using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectibleSystem : MonoBehaviour
{
    //Script Input di Koin
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Fungsi Menghilangkan Koin
            Destroy(gameObject);

            //(Place Holder) Fungsi Menambah Skor atau Jumlah Koin Terkumpul
            Debug.Log("Ambil Koin");
        }
    }
}
