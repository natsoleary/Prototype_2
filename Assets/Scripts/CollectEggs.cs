using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectEggs : MonoBehaviour {
    public AudioSource playSound;

    public static CollectEggs Player;

    private void Awake() {
        if (Player == null) Player = this;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Egg")) {
            Destroy(other.gameObject);
            Recipes.Instance.AddEgg();
            playSound.Play();
        }
    }
}
