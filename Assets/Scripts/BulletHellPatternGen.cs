using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;
using Unity.VisualScripting;
using UnityEngine;

public class BulletHellPatternGen : MonoBehaviour
{
    [Header("Refs")] public GameObject bulletPreFab;

    [Header("Attributes")] 
    [SerializeField] private Vector2 direction;
    [SerializeField] private float width;
    [SerializeField] private float waveDegree;
    [SerializeField] public bool start;
    [SerializeField] private float time;
    [SerializeField] private float rotationDegree;
    [SerializeField] private int numBullets;
    private Vector2 currentVec;
    private bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        currentVec = Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (canAttack)
            {
                Circle(currentVec, numBullets);
                // Wave(currentVec, numBullets, waveDegree);
                direction = RotateVector2d(direction, rotationDegree);
                currentVec = RotateVector2d(currentVec, rotationDegree);
                StartCoroutine(WaitForX(time));
            }
        }
    }

    public void Circle(Vector2 startVector, int numberBullets)
    {
        int interval = 360 / numberBullets;
        for (int i = 0; i < numberBullets; i++)
        {
            Vector2 dir = (Vector2)transform.position - RotateVector2d(startVector, interval * i);
            creBullet(dir, 0.1f);
        }
    }

    private void Wave(Vector2 startVector, int numberBullets, float degree)
    {
        for (int i = 0; i < numberBullets; i++)
        {
            Vector2 dir = (Vector2)transform.position - RotateVector2d(startVector, degree/numberBullets * i);
            creBullet(dir, 0.1f);
        }
    }
    
    private IEnumerator WaitForX(float time)
    {
        canAttack = false;
        yield return new WaitForSeconds(time);
        canAttack = true;
    }

    public void creBullet(Vector2 direction, float distance)
    {
        
        Vector3 pos = (direction * distance);
        pos += transform.position;
        Bullet bullet = Instantiate(bulletPreFab, pos, Quaternion.identity).GetComponent<Bullet>();
        bullet.SetDirection(direction);
    }
    public void creBulletAtPos(Vector2 direction, float distance, Vector3 position)
    {
        Bullet bullet = Instantiate(bulletPreFab, position, Quaternion.identity).GetComponent<Bullet>();
        bullet.SetDirection(direction);
    }
    

    static Vector2 RotateVector2d(Vector2 vec, float degrees)
    {
        float rad = degrees * Mathf.Deg2Rad;
        Vector2 result = new Vector2();
        result.x = vec.x * Mathf.Cos(rad) - vec.y * Mathf.Sin(rad);
        result.y = vec.x * Mathf.Sin(rad) + vec.y * Mathf.Cos(rad);
        return result;
    }
}