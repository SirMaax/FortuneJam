using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [Header("Refs")]
    public List<Sprite> sprites;
    

    [Header("Attributes")] 
    [SerializeField] private float bulletSpeed;
    private Enums.EnumBulletType bulletType;
    private Vector2 direction;

    [Header("Bounds")] 
    [SerializeField] private float xBound;
    [SerializeField] private float yBound;

    [SerializeField] private float a;
    [SerializeField] private float b;
    [Range(0,1)]
    [SerializeField] private float t;
    [SerializeField] private float step;
    [SerializeField] private float strength;
    // Start is called before the first frame update
    void Start()
    {
        ChangeAppearance();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        CheckBounds();
        transform.Translate(direction * bulletSpeed);
        // AddSecondaryMotion();
        AddThirdMotion();
    }

    private void AddSecondaryMotion()
    {
        t += step;
        if (t >= 1) step *=-1;
        if (t < 0) step *= -1;
        float value = Mathf.Lerp(a, b, t);
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, direction);
        Vector3 add = new Vector3(value, 0, 0);
        add = rotation * add;
        transform.Translate(add);
        Debug.DrawRay(transform.position,add);
    }

    private void AddThirdMotion()
    {
        Vector2 dir = Vector2.left;
        transform.Translate(dir * strength);
    }

    public void SetBulletType(Enums.EnumBulletType type)
    {
        bulletType = type;
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    private void ChangeAppearance()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[(int)bulletType];
    }

    private void CheckBounds()
    {
        Vector2 pos = transform.position;
        if (pos.x >= xBound || pos.x <= xBound * -1 || pos.y >= yBound || pos.y <= yBound * -1) Destroy(gameObject);

    }
    
    
}
