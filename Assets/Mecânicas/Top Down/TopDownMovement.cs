using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade de movimento
    private Rigidbody2D rb;       // Referência ao Rigidbody2D
    private Vector2 moveInput;    // Entrada do jogador (WASD ou setas)

    void Start()
    {
        // Obtém o Rigidbody2D do objeto
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura entrada horizontal e vertical
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Normaliza o vetor para que a diagonal não fique mais rápida
        moveInput.Normalize();

        // Opcional: gira o jogador na direção do movimento
        GirarParaMouse();
    }

    void GirarParaMouse()
    {
        // Pega a posição do mouse no mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Z sempre 0 no 2D

        // Calcula a direção do jogador para o mouse
        Vector3 direcao = (mousePos - transform.position).normalized;

        // Calcula o ângulo em graus usando Atan2 (y,x)
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

        // Aplica a rotação no eixo Z
        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }

    void FixedUpdate()
    {
        // Aplica a velocidade diretamente ao Rigidbody2D
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
