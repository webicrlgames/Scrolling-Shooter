using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletSpeed = 10f;

    public void Shoot()
    {
        Vector3 direccionDisparo = firePoint.right;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direccionDisparo));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = direccionDisparo * bulletSpeed;
    }
}

