using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCenter : MonoBehaviour
{
    [SerializeField]
    float speed;
    void Update()
    {
        transform.Translate((Vector3.zero-transform.position) * speed* Time.deltaTime, Space.World); //moves to center   
    }
}
