using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade de movimento
    private Rigidbody2D rb;       // Referência ao Rigidbody2D
    private Vector2 moveInput;    // Entrada do jogador (WASD ou setas)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // Impede que o Rigidbody2D rotacione o personagem
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
