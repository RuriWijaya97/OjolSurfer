using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TMP_Text coinText;
    public TMP_Text distanceText;

    public void UpdateCoinText(int coinVal)
    {
        coinText.text = coinVal.ToString();
    }

    public void DistanceUpdate(int distanceCal)
    {
       distanceText.text = distanceCal.ToString() + "m";
    }
}
