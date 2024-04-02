using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void Update()
    {
        Vector3 globalPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        globalPos.z = transform.position.z;

        Vector3 direction = (globalPos - transform.position).normalized;

        transform.up = direction;
    }
}
