using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject modeloObstaculo;

    [Header("Configuración del Juego")]
    public float tiempoEspera = 2.5f; // Tiempo entre obstáculos (Súbelo si salen muchos)
    public float alturaMinima = 0.5f; // La altura del suelo (para que no se entierre)
    public float alturaMaxima = 3.0f; // Lo más alto que puedes saltar

    void Start()
    {
        // Cancelamos por si acaso hubiera alguno pendiente
        CancelInvoke();
        // Iniciamos la máquina de crear
        InvokeRepeating("Crear", 0f, tiempoEspera);
    }

    void Crear()
    {
        // Elegimos una altura al azar entre el mínimo y el máximo que definas
        float yAleatoria = Random.Range(alturaMinima, alturaMaxima);

        // Usamos la posición X del Generador (donde lo pusiste lejos)
        // Pero usamos la Y aleatoria que acabamos de calcular
        Vector3 posicionNacimiento = new Vector3(transform.position.x, yAleatoria, transform.position.z);

        Instantiate(modeloObstaculo, posicionNacimiento, Quaternion.identity);
    }
}