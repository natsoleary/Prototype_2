using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Scores : MonoBehaviour
{
    public TextMeshProUGUI sweaterText;
    public TextMeshProUGUI eggText;


    void Update() {
        float breakfasts = Mathf.FloorToInt(Recipes.Instance.totalEggs / 3);
        float sweaters = Mathf.FloorToInt(Recipes.Instance.totalSheep / 2);
        sweaterText.text = sweaters.ToString();
        eggText.text = breakfasts.ToString();
    }
}
