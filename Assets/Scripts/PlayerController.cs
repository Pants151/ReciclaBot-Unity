using UnityEngine;
using UnityEngine.UI; // Necesario para la interfaz
using UnityEngine.SceneManagement; // Necesario para reiniciar el juego

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float xLimit = 8.5f; // Límite de la pantalla

    private int score = 0;
    public Text scoreText; // Arrastra el texto aquí en el Inspector

    public AudioSource audioSource;
    public AudioClip pointSound;
    public AudioClip bombSound;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveX * speed * Time.deltaTime);

        // Limitamos la posición X para no salir de pantalla
        float clampedX = Mathf.Clamp(transform.position.x, -xLimit, xLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Punto"))
        {
            score++;
            scoreText.text = "Puntos: " + score;
            audioSource.PlayOneShot(pointSound);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Obstaculo"))
        {
            audioSource.PlayOneShot(bombSound);
            Debug.Log("GAME OVER");
            Invoke("RestartGame", 0.5f); // Espera medio segundo para que suene el audio
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}