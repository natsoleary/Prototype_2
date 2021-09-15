using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresholdTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public int sheepValue = 1;
    public AudioSource playSound;
    public int pigValue = 1;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Sheep")) {
            Recipes.Instance.AddSheep();
            playSound.Play();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Pig")) {
            Recipes.Instance.AddPig();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Chicken")) {
            Recipes.Instance.AddChicken();
            Destroy(other.gameObject);
        }
    }
}
