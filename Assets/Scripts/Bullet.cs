using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifetime = 2f;
    private float speed = 25f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}