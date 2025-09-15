using UnityEngine;

public class BallBouncer : MonoBehaviour
{
    public float speed = 5f;          // Geschwindigkeit der Kugel
    public int maxBounces = 20;       // Maximale Anzahl der Abpraller

    private Rigidbody rb;
    private int bounceCount = 0;      // Zählt, wie oft die Kugel abgeprallt ist
    private Vector3 moveDirection = Vector3.right;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;

        // Startbewegung nach rechts
        rb.velocity = moveDirection * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            bounceCount++;

            if (bounceCount >= maxBounces)
            {
                rb.velocity = Vector3.zero; // Bewegung stoppen
                return;
            }

            // Bewegungsrichtung umkehren
            moveDirection = -moveDirection;
            rb.velocity = moveDirection * speed;
        }
    }
}
