using System;
using UnityEngine;

public class PlayerObserverManager : MonoBehaviour
{
    public static PlayerObserverManager Instancia { get; private set; }
    public static event Action<int> OnMoedasAlteradas;

    private int quantidadeMoedas = 0;
    public int QuantidadeMoedas => quantidadeMoedas;

    private void Awake()
    {
        if (Instancia == null) Instancia = this;
        else Destroy(gameObject);
    }

    public void AdicionarMoeda()
    {
        quantidadeMoedas++;
        
        // RASTREADOR 4: O número mudou no script principal?
        Debug.Log($"[GERENCIADOR] Moeda somada! Novo total: {quantidadeMoedas}. Disparando evento para a UI...");

        OnMoedasAlteradas?.Invoke(quantidadeMoedas);
    }
}