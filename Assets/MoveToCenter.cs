using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCenter : MonoBehaviour
{
    [SerializeField]
    float speed;
    void Update()
    {
        transform.Translate(-1f * transform.position * speed* Time.deltaTime); //moves to center   
    }
}
