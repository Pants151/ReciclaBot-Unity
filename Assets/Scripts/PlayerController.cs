using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveX * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Punto"))
        {
            Destroy(other.gameObject); // Recoge el punto
            Debug.Log("¡Punto!");
        }
        else if (other.CompareTag("Obstaculo"))
        {
            Debug.Log("FIN DEL JUEGO"); // Aquí podrías reiniciar el nivel
        }
    }
}