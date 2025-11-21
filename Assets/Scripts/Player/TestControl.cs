using UnityEngine;


public class TopDownCamera : MonoBehaviour
{
    public float movementSpeed = 15f;
    public float fastMovementSpeed = 40f;

    public float zoomSpeed = 200f;
    public float minZoom = 10f;
    public float maxZoom = 120f;

    [Tooltip("Angle the camera looks down from.")]
    public float topDownAngle = 60f;

    void Start()
    {
        // Lock camera rotation to a top-down angle
        transform.rotation = Quaternion.Euler(topDownAngle, 0f, 0f);
    }

    void Update()
    {
        bool fast = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float speed = fast ? fastMovementSpeed : movementSpeed;

        Vector3 pos = transform.position;

        // Move on XZ plane only
        if (Input.GetKey(KeyCode.UpArrow))
            pos += Vector3.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.DownArrow))
            pos += Vector3.back * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
            pos += Vector3.left * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
            pos += Vector3.right * speed * Time.deltaTime;

        // Zoom (adjust camera height)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            pos.y -= scroll * zoomSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minZoom, maxZoom);
        }

        transform.position = pos;
    }
}

