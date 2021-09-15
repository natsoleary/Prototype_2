using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    public float moveSpeed;
    public float runAwayRadius;
    
    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(CollectEggs.Player.transform.position, transform.position) < runAwayRadius) {
            Vector3 dir = transform.position - CollectEggs.Player.transform.position; 
            dir.Normalize();
            transform.Translate(moveSpeed * Time.deltaTime * dir);
        }
    }
}
