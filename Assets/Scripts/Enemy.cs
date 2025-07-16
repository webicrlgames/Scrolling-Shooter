using UnityEngine;

public class MovimientoEnemy : MonoBehaviour
{
    public float velocidad = 5f;
    public float limiteX = -20f;
    public int vida = 10;

    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);

        if (transform.position.x < limiteX)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            RecibirDanio();
        }
    }
    public void RecibirDanio()
    {
        vida -= 1;
        Debug.Log("Enemigo recibió daño. Vida restante: " + vida);

        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Destroy(gameObject);
    }

}