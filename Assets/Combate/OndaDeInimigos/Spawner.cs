using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Configuração do Spawn")]
    public GameObject inimigoPrefab;     // Prefab do inimigo
    public Transform[] pontosDeSpawn;    // Locais possíveis de aparecimento

    public void SpawnarInimigo()
    {
        if (inimigoPrefab == null || pontosDeSpawn.Length == 0) return;

        // Escolhe um ponto aleatório
        Transform ponto = pontosDeSpawn[Random.Range(0, pontosDeSpawn.Length)];

        // Instancia o inimigo
        Instantiate(inimigoPrefab, ponto.position, Quaternion.identity);
    }
}
