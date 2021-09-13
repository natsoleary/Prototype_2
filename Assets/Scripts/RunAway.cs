using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    public float moveSpeed;
    public GameObject Player;
    
    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(Player.transform.position, transform.position) < 3) {
            Vector3 dir = transform.position - Player.transform.position; 
            dir.Normalize();
            transform.Translate(moveSpeed * Time.deltaTime * dir);
        }
    }
}
