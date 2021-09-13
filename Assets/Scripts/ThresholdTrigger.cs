using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresholdTrigger : MonoBehaviour
{
    // Start is called before the first frame update
public int sheepValue = 1;
public AudioSource playSound;


private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Sheep")) {
        SheepCounter.instance.UpdateScore(sheepValue);
        playSound.Play();
        Destroy(other.gameObject);


    }

}
}
