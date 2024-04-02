using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    float speed = 45;
    Rigidbody2D rb;




    public void SetSpeedAndDirection(float speed, Vector3 direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
    }



}