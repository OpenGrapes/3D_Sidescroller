using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 5.0f;
    public float jumpForce = 5.0f;  // Erhöhe den Wert für einen besseren Sprung
    private bool isGrounded;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRigidbody.AddForce(new Vector3(-horizontalInput, 0.0f, -verticalInput) * speed);

        // Springen nur, wenn auf dem Boden
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Spieler ist in der Luft
        }
    }

    // Prüfen, ob der Spieler auf dem Boden ist
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Spieler ist wieder auf dem Boden
        }
    }
}
