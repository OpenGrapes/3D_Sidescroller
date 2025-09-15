using UnityEngine;

public class FollowerBall : MonoBehaviour
{
    public Transform target; // Die zu verfolgende Kugel
    public float followDistanceX = 2.0f; // Abstand auf der X-Achse
    public float followDistanceY = 1.0f; // Abstand auf der Y-Achse
    public float followSpeed = 5.0f; // Geschwindigkeit der Verfolgung

    void Update()
    {
        if (target != null)
        {
            // Zielposition mit Abstand berechnen
            Vector3 targetPosition = new Vector3(target.position.x - followDistanceX,
                                                 target.position.y - followDistanceY,
                                                 target.position.z);

            // Berechne den Richtungsvektor zum Ziel
            Vector3 direction = (targetPosition - transform.position).normalized;

            // Berechne die neue Position mit Lerp (sanfte Bewegung)
            Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // Setze die neue Position direkt
            transform.position = newPosition;
        }
    }
}
