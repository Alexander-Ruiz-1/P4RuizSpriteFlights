using UnityEngine.InputSystem;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float thrustForce = 1f;
    public float maxSpeed = 5f;
    public GameObject boosterFlame;
    public GameObject innerboosterFlame;
        Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()

    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            boosterFlame.SetActive(true);
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            boosterFlame.SetActive(false);
        }
        if (Mouse.current.leftButton.isPressed)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                innerboosterFlame.SetActive(true);
            }
            else if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                innerboosterFlame.SetActive(false);
            }
            //Calculate Mouse Direction
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;

            //Move Player in Direction of Mouse
            transform.up = direction;
            rb.AddForce(direction * thrustForce);
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
            
        }
    }
    void OnCollisionEnter2D(Collision2D collosion)
    {
        Destroy(gameObject);
    }
}
