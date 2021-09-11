using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    public float moveSpeed;
    
    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(MouseFollow.Instance.transform.position, transform.position) < 3) {
            Vector3 dir = transform.position - MouseFollow.Instance.transform.position; 
            dir.Normalize();
            transform.Translate(moveSpeed * Time.deltaTime * dir);
        }
    }
}
