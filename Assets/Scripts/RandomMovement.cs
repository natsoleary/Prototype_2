using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

    public float moveSpeed;
    public int rotateAngle;
    
    private const float changeDirectionTime = 2.0f;
    private float timeBeforeDirectionChange;

    // Start is called before the first frame update
    void Start() {
        timeBeforeDirectionChange = changeDirectionTime;
        transform.Rotate(0, 0, Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update() {
        timeBeforeDirectionChange -= Time.deltaTime;
        if (timeBeforeDirectionChange <= 0.0f) {
            timeBeforeDirectionChange = changeDirectionTime;

            transform.Rotate(0, 0, Random.Range(-rotateAngle, rotateAngle));
        }
        
        transform.Translate(moveSpeed * Time.deltaTime * transform.right);
    }
}
