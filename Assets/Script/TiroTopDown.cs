using UnityEngine;

public class TiroTopDown : MonoBehaviour
{
    [Header("Configura��es do Tiro")]
    public GameObject prefabProjetil; // Prefab do proj�til que ser� instanciado ao atirar
    public float velocidadeProjetil = 10f; // Velocidade do proj�til
    public float tempoEntreTiros = 0.3f;   // Tempo m�nimo entre tiros consecutivos

    public Transform pontoTiro; // Ponto de onde o proj�til ser� disparado

    private float tempoProximoTiro = 0f; // Guarda o tempo em que o jogador pode atirar novamente

    void Update()
    {
        // Pega a posi��o do mouse no mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Z sempre 0 no 2D

        // Rotaciona o jogador para olhar na dire��o do mouse
        GirarParaMouse(mousePos);

        // Verifica se o bot�o esquerdo do mouse foi pressionado e se j� passou o tempo de cooldown
        if (Input.GetMouseButton(0) && Time.time >= tempoProximoTiro)
        {
            Atirar(mousePos); // Passa a posi��o do mouse para o m�todo Atirar
            tempoProximoTiro = Time.time + tempoEntreTiros; // Atualiza o tempo do pr�ximo tiro permitido
        }
    }

    // M�todo que gira o jogador na dire��o do mouse
    void GirarParaMouse(Vector3 mousePos)
    {
        // Calcula a dire��o do jogador para o mouse
        Vector3 direcao = (mousePos - transform.position).normalized;

        // Calcula o �ngulo em graus usando Atan2 (y,x)
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

        // Aplica a rota��o no eixo Z
        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }

    // M�todo que instancia o proj�til e define sua dire��o e velocidade
    void Atirar(Vector3 mousePos)
    {
        // Instancia o prefab do proj�til na posi��o do ponto de tiro
        GameObject proj = Instantiate(prefabProjetil, pontoTiro.position, Quaternion.identity);

        // Calcula a dire��o do proj�til em dire��o ao mouse
        Vector2 direcao = (mousePos - proj.transform.position).normalized;

        // Aplica velocidade ao Rigidbody2D do proj�til
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direcao * velocidadeProjetil;
    }
}
