using UnityEngine;

public class CameraController : MonoBehaviour
{
        public Transform target;
        public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void Update()
    {
        transform.position = target.position + offset;
    }
}