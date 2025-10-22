# 🌊 Ondas de Inimigos

## 📖 Descrição
Cria ondas sucessivas de inimigos que aparecem em pontos específicos do cenário.  
Cada nova onda começa após todos os inimigos da anterior serem derrotados.  
Ideal para fases de progressão ou arenas de combate em jogos *beat’em up*.

---

## 🛠️ Passo a Passo
1. Crie um objeto vazio chamado `GameManager` e adicione o script `WaveManager.cs`.
2. Crie outro objeto chamado `Spawner` e adicione o script `Spawner.cs`.
3. No `Spawner`, defina:
   - O **prefab do inimigo** a ser instanciado.
   - Uma lista de **pontos de spawn** (crie *Empty Objects* na cena).
4. No `WaveManager`, configure:
   - O array `inimigosPorOnda`, por exemplo `[3, 5, 8]`. Adicione ondas clicando em + e colocando o número de inimigos naquela onda
   - O tempo entre ondas.
   - A referência para o `Spawner`.
5. Adicione o script `InimigoWave` no prefab do inimigo.
6. Certifique-se de que:
   - Os inimigos tenham a tag **"Inimigo"**.
   - O jogador tenha a tag **"Player"**.
