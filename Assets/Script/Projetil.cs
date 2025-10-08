using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float dano = 10f; // Dano que o proj�til causa
    public float tempoDeVida = 3f; // Tempo antes de ser destru�do automaticamente

    void Start()
    {
        // Destroi o proj�til ap�s o tempo definido para evitar ac�mulo na cena
        Destroy(gameObject, tempoDeVida);
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        // Se o proj�til colidir com um inimigo...
        if (colisao.CompareTag("Inimigo"))
        {
            // Aplica dano ao inimigo, caso ele tenha o script Vida
            colisao.GetComponent<Vida>()?.ReceberDano(dano);

            // Destroi o proj�til ap�s o impacto
            Destroy(gameObject);
        }
    }
}