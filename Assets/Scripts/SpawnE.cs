using System;
using UnityEngine;

public class SpawnE : MonoBehaviour
{
    public GameObject enemigoPrefab;   // Prefab del enemigo a instanciar
    public float intervaloSpawn = 0.2f; // Tiempo entre intentos de spawn
    [Range(0f, 1f)]
    public float probabilidadSpawn = 0.3f; // 30% de probabilidad

    void Start()
    {
        // Inicia el ciclo de spawn con un intervalo
        InvokeRepeating(nameof(IntentarSpawnear), 1f, intervaloSpawn);
    }

    void IntentarSpawnear()
    {
        float prob = UnityEngine.Random.Range(0f, 1f);  // Usar explicitamente UnityEngine.Random

        // Si el número es menor o igual a la probabilidad, se instancia el enemigo
        if (prob <= probabilidadSpawn)
        {
            InstanciarEnemigo();
        }
    }

    void InstanciarEnemigo()
    {
        // Instancia el enemigo en la posición del objeto SpawnE
        Instantiate(enemigoPrefab, transform.position, Quaternion.identity);
    }
}