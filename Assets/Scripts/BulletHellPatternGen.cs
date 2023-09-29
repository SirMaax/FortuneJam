using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;

public class BulletHellPatternGen : MonoBehaviour
{
    [Header("Refs")] 
    public GameObject bulletPreFab;
    
    
    [SerializeField] 
    public bool start;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            TestRun();
        }    
    }

    public void TestRun()
    {
        Vector2 direction = Quaternion.LookRotation()
        Vector3 pos = 
        Instantiate(bulletPreFab,)
    }
}
