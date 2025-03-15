using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    bool blockUp, blockDown, blockLeft, blockRight;
    public string inputMode = "Normal";

    public bool isPlayerAlive = true;
    public DeathEffect deathEffectScript;

    public string diedBy = "Null";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isPlayerAlive) {
            float moveX = 0f, moveY = 0f;
            blockUp = blockDown = blockLeft = blockRight = false;

            bool upPressed = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
            bool downPressed = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
            bool leftPressed = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
            bool rightPressed = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

            if (inputMode == "Normal")
            {
                if (upPressed && !blockUp) moveY += 1f;
                if (downPressed && !blockDown) moveY -= 1f;
                if (leftPressed && !blockLeft) moveX -= 1f;
                if (rightPressed && !blockRight) moveX += 1f;
            }
            else if (inputMode == "Reverse")
            {
                if (upPressed && !blockDown) moveY -= 1f;
                if (downPressed && !blockUp) moveY += 1f; 
                if (leftPressed && !blockRight) moveX += 1f;
                if (rightPressed && !blockLeft) moveX -= 1f;
            }
            movement = (new Vector2(moveX, moveY)) * speed;
        } else {
            movement = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Laser") && isPlayerAlive == true) {
            isPlayerAlive = false;
            diedBy = "Laser";
            deathEffectScript.TriggerDeathEffect();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Vector2 normal = contact.normal;

            if (normal.x > 0.5f) blockLeft = true;
            if (normal.x < -0.5f) blockRight = true;
            if (normal.y > 0.5f) blockDown = true;
            if (normal.y < -0.5f) blockUp = true;
        }
    }
}
