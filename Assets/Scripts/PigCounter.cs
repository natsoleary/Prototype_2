using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PigCounter : MonoBehaviour
{
    public static PigCounter instance;
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
    public void UpdateScore(int pig) {
        score += pig;
        StaticVariables.pigCount = score;
        text.text = ": " +score.ToString();
    }
}
