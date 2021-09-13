using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SheepCounter : MonoBehaviour
{
    public static SheepCounter instance;
    public TextMeshProUGUI text;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }

    // Update is called once per frame
    public void UpdateScore(int sheep) {
        score += sheep;
        StaticVariables.sheepCount = score;
        text.text = "Sheep: " + score.ToString();
    }
}
