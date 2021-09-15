using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

    public float moveSpeed;
    public int playerDeactivateRadius;
    
    private const float ChangeDirectionTime = 2.0f;
    private float timeBeforeDirectionChange;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start() {
        timeBeforeDirectionChange = ChangeDirectionTime;
        moveDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        moveDirection.Normalize();
    }

    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(CollectEggs.Player.transform.position, transform.position) < playerDeactivateRadius) {
            return;
        }
        
        timeBeforeDirectionChange -= Time.deltaTime;
        if (timeBeforeDirectionChange <= 0.0f) {
            timeBeforeDirectionChange = ChangeDirectionTime;
            
            moveDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            moveDirection.Normalize();
        }
        
        transform.Translate(moveSpeed * Time.deltaTime * moveDirection);
    }
}
