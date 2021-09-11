using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < 3) {
        var moveSpeed = 5.0;
        Vector3 dir = transform.position - Player.transform.position; 
        dir.Normalize();
        var distance = moveSpeed * Time.deltaTime;
        transform.Translate(dir * (float)distance);
        }
    }
}
