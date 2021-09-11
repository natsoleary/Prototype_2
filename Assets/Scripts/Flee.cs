using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    // Start is called before the first frame update
private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Sheep")) {
        // Quaternion rotation = Quaternion.LookRotation
        //      (transform.position - other.transform.position, other.transform.TransformDirection(Vector3.up));
        //  other.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        // // other.transform.LookAt(transform.position);
        // // other.transform.Rotate(0, 180, 0);
        // other.transform.Translate(Vector3.forward);        
        var moveSpeed = 5.0;
        Vector3 dir = transform.position - other.transform.position; 
        dir.Normalize();
        var distance = -moveSpeed * Time.deltaTime;
        other.transform.Translate(dir * (float)distance);
    }


}
}
