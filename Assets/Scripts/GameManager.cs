using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TMP_Text coinText; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void UpdateCoinText(int coinVal)
    {
        coinText.text = coinVal.ToString();
    }

}
