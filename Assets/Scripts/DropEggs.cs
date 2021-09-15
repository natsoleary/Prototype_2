using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEggs : MonoBehaviour {

    public float dropTimeMin = 1.0f;
    private float dropTimeMax;
    
    private float timeUntilNextDrop;

    public GameObject eggPrefab;
    
    // Start is called before the first frame update
    void Start() {
        dropTimeMax = dropTimeMin + 5.0f;
        timeUntilNextDrop = Random.Range(0.0f, dropTimeMin);
    }

    // Update is called once per frame
    void Update() {
        timeUntilNextDrop -= Time.deltaTime;

        if (timeUntilNextDrop <= 0) {
            // reset drop time 
            timeUntilNextDrop = Random.Range(dropTimeMin, dropTimeMax);
            // drop an egg
            Instantiate(eggPrefab, transform.position, Quaternion.identity);
        }
    }
}
