using UnityEngine;

public class PortaComChave : MonoBehaviour
{
    public Animator anim; // Controlador de animação da porta
    private bool aberta = false; // Estado atual da porta
    public Inventario inventario; // Referência ao inventário do jogador

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o jogador encostou na porta
        if (collision.CompareTag("Player"))
        {
            // Acessa o inventário do jogador
            Inventario inventario = collision.GetComponent<Inventario>();

            // Se o jogador tem o script e possui chave
            if (inventario != null && !aberta)
            {
                // Remove uma chave do inventário
                inventario.RemoverItem("chave", 1);

                // Toca animação de abrir porta
                anim.SetTrigger("Abrir");
                aberta = true;
            }
        }
    }
}
