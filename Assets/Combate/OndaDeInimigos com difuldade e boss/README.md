# 🌊 Wave Manager Avançado

## 📖 Descrição
Gerencia o **sistema de ondas de inimigos** (spawn sequencial com aumento de dificuldade).  
Permite definir o número de inimigos por onda, a inserção de **chefes em ondas específicas**,  
e um **escala de dificuldade automática** que aumenta vida, dano e velocidade dos inimigos.  

Ideal para jogos de ação, arena ou beat'em up.

---

## 🛠️ Passo a Passo

1. Crie um objeto vazio chamado `GameManager` e adicione o script `WaveManagerAvançado.cs`.
2. Crie **pontos de spawn** (vários `Empty GameObjects`) no cenário e arraste para o array `pontosSpawn`.
4. Adicione os **prefabs de inimigos** (`inimigoBasicoPrefab` e `inimigoChefePrefab`).
5. Configure:
   - `inimigosPorOnda` → quantos inimigos surgem por rodada (ex: `[3, 5, 8, 10]`)
   - `ondasComChefe` → índices de ondas que terão chefes (ex: `[3, 5]`)
   - `tempoEntreOndas` → intervalo entre uma onda e outra
6. Ajuste os multiplicadores de dificuldade para **vida, dano e velocidade** conforme desejado.
