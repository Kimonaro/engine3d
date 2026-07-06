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
        if (Instancia == null) 
        {
            Instancia = this;
            // ESSENCIAL: Impede que o contador de moedas seja destruído ao mudar de cena
            DontDestroyOnLoad(gameObject); 
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void AdicionarMoeda()
    {
        quantidadeMoedas++;
        Debug.Log($"[GERENCIADOR] Moeda somada! Novo total: {quantidadeMoedas}. Disparando evento para a UI...");
        OnMoedasAlteradas?.Invoke(quantidadeMoedas);
    }
}