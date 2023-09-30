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

    [Header("Player Controls")] 
    public bool invincible;
    [SerializeField] private float invincibleCooldown;
    
    [Header("Shooting")] 
    private bool canShoot;
    [SerializeField] private float shootingCooldown;
    private int magazinSize = 6;
    private int usedBullets = 0;
    [SerializeField] private float reloadTime;
    
    [Header("Dodge")] 
    private bool canDodge = true;
    [SerializeField] private float dodgeCooldown;
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
        if (canShoot && usedBullets != 6)
        {
            usedBullets += 1;
            Shoot();
            StartCoroutine(ShootingCooldown());
        }
        else if (usedBullets == 6)
        {
            Reload();
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
    
    public void Dodge()
    {
        if (canDodge)
        {
            StartCoroutine(DodgeCooldown());
            
        }
    }
    
    IEnumerator DodgeCooldown()
    {
        canDodge = false;
        invincible = true;
        yield return new WaitForSeconds(invincibleCooldown);
        invincible = false;
        yield return new WaitForSeconds(dodgeCooldown);
        canDodge = true;
    }

    public void Reload()
    {
        StartCoroutine(ReloadCooldown());

    }
    IEnumerator ReloadCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        usedBullets = 0;
        canShoot = true;
    }
}
