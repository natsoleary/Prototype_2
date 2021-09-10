using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
Vector3 mousePosition;
public float speed = 0.1f;

Rigidbody2D rb;
Vector2 position = new Vector2(0f, 0f);

private void Start() {
    rb = GetComponent<Rigidbody2D>();

}
private void Update() {
    mousePosition = Input.mousePosition;
    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    position = Vector2.Lerp(transform.position, mousePosition, speed);

}

private void FixedUpdate() {
    rb.MovePosition(position);
}


}
