using UnityEngine;

public class FallingItem : MonoBehaviour
{
    public float fallSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Destruir si sale de la pantalla para no gastar memoria
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}