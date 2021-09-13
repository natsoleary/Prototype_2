using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 45;
    public TextMeshProUGUI timerText;
    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0) {
            timeValue -= Time.deltaTime;
        }
        else {
            SceneManager.LoadScene (sceneName:"EndScreen");

        }
    Display(timeValue);
    }
    void Display(float displayTime) {
        if(timeValue < 0) {
            timeValue = 0;
        }
        float seconds = Mathf.FloorToInt(timeValue);

        timerText.text = seconds.ToString();
    }
}
