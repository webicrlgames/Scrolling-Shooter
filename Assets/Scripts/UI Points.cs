using UnityEngine;
using TMPro;
using System.Collections;

public class UIPoints : MonoBehaviour
{
    public TextMeshProUGUI puntosTexto;  // Referencia al texto TMP
    public int puntos = 0;
    public float intervalo = 0.5f;

    private void Start()
    {
        StartCoroutine(ContarPuntos());
    }

    IEnumerator ContarPuntos()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalo);
            puntos++;
            ActualizarUI();
        }
    }

    void ActualizarUI()
    {
        if (puntosTexto != null)
        {
            puntosTexto.text = "Puntos: " + puntos.ToString();
        }
    }
}