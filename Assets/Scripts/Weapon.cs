using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public float bulletSpeed = 20f;

    public void Shoot()
    {
        firePoint = GetComponentsInChildren<Transform>()
                .FirstOrDefault(t => t.CompareTag("BSpawn"))?.gameObject;

        if (firePoint == null)
        {
            Debug.LogError("El firePoint no está asignado.");
            return;
        }

        Debug.Log("Disparando...");
        if (bulletPrefab != null )
        {
            Debug.Log("Disparo");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = firePoint.transform.forward * bulletSpeed;
            }
        }
    }
}

