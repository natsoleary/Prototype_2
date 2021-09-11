using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEggs : MonoBehaviour {

    private const float DropTimeMin = 2.0f;
    private const float DropTimeMax = 6.0f;
    
    private float timeUntilNextDrop;

    public GameObject eggPrefab;
    
    // Start is called before the first frame update
    void Start() {
        timeUntilNextDrop = Random.Range(DropTimeMin, DropTimeMax);
    }

    // Update is called once per frame
    void Update() {
        timeUntilNextDrop -= Time.deltaTime;

        if (timeUntilNextDrop <= 0) {
            // reset drop time 
            timeUntilNextDrop = Random.Range(DropTimeMin, DropTimeMax);
            // drop an egg
            Debug.Log("egg drop");
            Instantiate(eggPrefab, transform.position, Quaternion.identity);
        }
    }
}
