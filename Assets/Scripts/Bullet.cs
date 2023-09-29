using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [Header("Refs")]
    public List<Sprite> sprites;
    

    [Header("Attributes")] 
    [SerializeField] private float bulletSpeed;
    private Enums.EnumBulletType bulletType;
    private Vector2 direction;
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeAppearance();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(direction * bulletSpeed);
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
}
