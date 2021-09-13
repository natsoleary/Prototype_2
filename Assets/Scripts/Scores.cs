using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Scores : MonoBehaviour
{
    public TextMeshProUGUI sweaterText;
    public TextMeshProUGUI eggText;


    void Update() {

        float breakfasts = Mathf.FloorToInt(StaticVariables.eggCount / 3);
        float sweaters = Mathf.FloorToInt(StaticVariables.sheepCount / 2);
        sweaterText.text = sweaters.ToString();
        eggText.text = breakfasts.ToString();


    }

}
