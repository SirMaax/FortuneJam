using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Refs")]
    public GameObject bulletPreFab;
    public GameObject aimCircle;
    
    [Header("Shooting")] 
    private bool canShoot;
    [SerializeField] private float shootingCooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootPrep()
    {
        if (canShoot)
        {
            Shoot();
            StartCoroutine(ShootingCooldown());
        }
        
    }

    private void Shoot()
    {
        Vector2 direction = (aimCircle.transform.position - transform.position).normalized;
        // Instantiate(bulletPreFab, transform.position, Quaternion.LookRotation((Vector3)direction, Vector3.up));
        Bullet bullet = Instantiate(bulletPreFab, transform.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.SetBulletType(Enums.EnumBulletType.player);
        bullet.SetDirection(direction);
    }
    
    IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootingCooldown);
        canShoot = true;
    }
}
