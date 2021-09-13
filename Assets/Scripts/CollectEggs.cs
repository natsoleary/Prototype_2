using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectEggs : MonoBehaviour {
    private int eggsCollected = 0;
    public AudioSource playSound;
    public TextMeshProUGUI text;
    float score = 0;



    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Egg")) {
            Destroy(other.gameObject);
            eggsCollected++;
            Debug.Log(eggsCollected);
            playSound.Play();
            score += 1;
            text.text = "Eggs: " + score.ToString();
            StaticVariables.eggCount = score;
            
        }
    }
}
