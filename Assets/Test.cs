using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position,(Vector3) direction + transform.position,Color.blue);
        
        Vector3 dir = Vector3.right;
        Quaternion quat = Quaternion.FromToRotation(Vector3.up, direction);
        dir = quat * dir;
        Debug.DrawRay((Vector3) direction + transform.position,dir,Color.red);
    }
}
