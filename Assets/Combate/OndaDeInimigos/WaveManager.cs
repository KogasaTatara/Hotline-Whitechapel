using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    [Header("Configurações das Ondas")]
    public int[] inimigosPorOnda;        // Quantidade de inimigos por onda
    public float tempoEntreOndas = 3f;   // Intervalo entre as ondas
    public Spawner spawner;              // Referência ao objeto que gera inimigos

    private int ondaAtual = 0;           // Índice da onda atual
    private bool gerando = false;        // Evita duplicar corrotinas

    void Start()
    {
        StartCoroutine(ControlarOndas());
    }

    private IEnumerator ControlarOndas()
    {
        yield return new WaitForSeconds(2f); // Pequena pausa inicial

        while (ondaAtual < inimigosPorOnda.Length)
        {
            if (!gerando)
            {
                gerando = true;
                Debug.Log($"Iniciando Onda {ondaAtual + 1}");
                yield return StartCoroutine(GerarOnda(inimigosPorOnda[ondaAtual]));
                gerando = false;

                ondaAtual++;
                if (ondaAtual < inimigosPorOnda.Length)
                {
                    Debug.Log($"Aguardando {tempoEntreOndas}s para próxima onda...");
                    yield return new WaitForSeconds(tempoEntreOndas);
                }
            }
            yield return null;
        }

        Debug.Log("🔥 Todas as ondas foram concluídas!");
    }

    private IEnumerator GerarOnda(int quantidade)
    {
        // Gera os inimigos da onda atual
        for (int i = 0; i < quantidade; i++)
        {
            spawner.SpawnarInimigo();
            yield return new WaitForSeconds(1f); // Delay entre inimigos
        }

        // Se quiser implementar espera até que todos os inimigos tenham sido derrotados,
        // descomente a linha abaixo
        
        // yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Inimigo").Length == 0);
    }
}