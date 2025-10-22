# 🔑 Porta com Chave

## 📖 Descrição
Permite que o jogador abra uma porta apenas se possuir a chave correta no inventário.  
Integra-se com o sistema de **Inventário Simples** da pasta `/Coletaveis/`.

---

## 🛠️ Passo a Passo
1. Certifique-se de que a cena tenha um GameObject `Inventario` contendo o script `Inventario`.
2. Crie uma `Chave` com o script `ItemColetavel.cs` (nome do item: `"Chave"`).
3. Crie uma `Porta` com `Collider2D` e adicione o script `Porta.cs`.
4. Defina no Inspector:
   - `nomeChaveNecessaria = "Chave"`
   - `precisaConsumirChave = true`
5. (Opcional) Adicione `Animator` com trigger `"Abrir"`.