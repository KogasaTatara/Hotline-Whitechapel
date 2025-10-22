using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerTopDown : MonoBehaviour
{
    [Header("Movimento")]
    public float moveSpeed = 5f;

    [Header("Tiro")]
    public GameObject prefabProjetil;
    public Transform pontoTiro;
    public float velocidadeProjetil = 10f;
    public float tempoEntreTiros = 0.3f;

    [Header("Ajustes")]
    public float spriteAngleOffset = 0f; // use 90 se o sprite "aponta" para cima, 0 se aponta para direita

    Rigidbody2D rb;
    Vector2 moveInput;
    float tempoProximoTiro = 0f;
    float anguloAlvo = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = false; // permitir rota��o via Rigidbody2D
    }

    void Update()
    {
        // entrada de movimento
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        // mouse world
        Camera cam = Camera.main;
        if (cam == null) return; // preven��o caso MainCamera n�o exista
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        // determina �ngulo alvo e aplica offset do sprite
        Vector2 dir = (mousePos - transform.position).normalized;
        if (dir.sqrMagnitude > 0.0001f)
        {
            anguloAlvo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + spriteAngleOffset;
        }

        // tiro
        if (prefabProjetil != null && pontoTiro != null && Input.GetMouseButton(0) && Time.time >= tempoProximoTiro)
        {
            Atirar(mousePos);
            tempoProximoTiro = Time.time + tempoEntreTiros;
        }
       Debug.Log(
                "DEBUG: mousePos=" + mousePos +
                " | playerPos=" + transform.position +
                " | dir=" + dir +
                " | anguloAlvo=" + anguloAlvo.ToString("F2") +
                " | rb.rotation=" + rb.rotation.ToString("F2") +
                " | moveInput=" + moveInput
            );
        if (prefabProjetil != null && pontoTiro != null && Input.GetMouseButton(0) && Time.time >= tempoProximoTiro)
        {
            Atirar(mousePos);
            tempoProximoTiro = Time.time + tempoEntreTiros;
            Debug.Log("DEBUG: Tiro instanciado. pontoTiro=" + pontoTiro.position);
        }
    
}

    void FixedUpdate()
    {
        // movimento
        rb.linearVelocity = moveInput * moveSpeed;

        // rota��o via Rigidbody2D
        rb.MoveRotation(anguloAlvo);
    }

    void Atirar(Vector3 mousePos)
    {
        GameObject proj = Instantiate(prefabProjetil, pontoTiro.position, Quaternion.identity);
        Rigidbody2D projRb = proj.GetComponent<Rigidbody2D>();
        if (projRb == null)
        {
            Destroy(proj);
            Debug.LogWarning("Projetil precisa de Rigidbody2D");
            return;
        }

        Vector2 dir = (mousePos - proj.transform.position).normalized;
        projRb.linearVelocity = dir * velocidadeProjetil;
        float projAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        proj.transform.rotation = Quaternion.Euler(0, 0, projAngle + spriteAngleOffset);
    }
}