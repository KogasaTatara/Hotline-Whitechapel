using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InimigoIA_PlayerLikeMovement : MonoBehaviour
{
    [Header("Alvo e Movimento")]
    public Transform player;
    public float velocidade = 3f;
    public float distanciaMinima = 1f; // quando menor que isso, para e ataca

    [Header("Ataque")]
    public float tempoEntreAtaques = 5f;
    public float dano = 10f;

    [Header("Ajustes visuais")]
    public float spriteAngleOffset = 0f; // se o sprite precisa de offset na rotação
    public bool flipWithX = true; // espelhar via escala X quando mover para a esquerda

    Rigidbody2D rb;
    Vector2 direcao;
    float tempoProximoAtaque = 0f;
    float anguloAlvo = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = false;
    }

    void Update()
    {
        if (player == null) return;

        // calcula direção 2D completa (player - inimigo)
        Vector2 diff = (player.position - transform.position);
        float dist = diff.magnitude;

        if (dist > 0.0001f)
        {
            direcao = diff / dist; // normalizado
            anguloAlvo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg + spriteAngleOffset;
        }
        else
        {
            direcao = Vector2.zero;
        }

        // ataque quando dentro da distância mínima
        if (dist <= distanciaMinima && Time.time >= tempoProximoAtaque)
        {
            rb.linearVelocity = Vector2.zero;
            var vida = player.GetComponent<VidaComVulnerabilidade>();
            if (vida != null)
            {
                vida.ReceberDano(dano, transform.position);
            }
            tempoProximoAtaque = Time.time + tempoEntreAtaques;
        }
    }

    void FixedUpdate()
    {
        // aplica movimento igual ao player: direção normalizada * velocidade
        // se estiver dentro da distância mínima, Update já zera velocity antes do ataque
        float distToPlayer = Vector2.Distance(player.position, transform.position);
        if (distToPlayer > distanciaMinima)
        {
            rb.linearVelocity = direcao * velocidade;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

        // aplica rotação física para mirar no player (opcional)
        rb.MoveRotation(anguloAlvo);

        // espelhar sprite pela escala X se desejar (útil para sprites 2D sem rotação)
        if (flipWithX && Mathf.Abs(direcao.x) > 0.01f)
        {
            Vector3 s = transform.localScale;
            s.x = Mathf.Sign(direcao.x) * Mathf.Abs(s.x);
            transform.localScale = s;
        }
    }
}
