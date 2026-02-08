using UnityEngine;

public class MoverObstaculo : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        // Mueve el objeto hacia la izquierda constantemente
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);

        // Limpieza: Si se va muy lejos (fuera de pantalla), se autodestruye
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}