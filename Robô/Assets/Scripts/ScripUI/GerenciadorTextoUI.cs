using UnityEngine;
using TMPro;

public class GerenciadorTextoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoMoedas; 

    private void Start()
    {
        // 1. Nos inscrevemos no canal de forma segura aqui no Start
        // Tiramos do OnEnable para evitar problemas se a cena carregar em tempos diferentes
        PlayerObserverManager.OnMoedasAlteradas -= AtualizarTextoMoedas; // Prevenção de duplicados
        PlayerObserverManager.OnMoedasAlteradas += AtualizarTextoMoedas;

        // 2. Busca o valor que JÁ ESTÁ no gerenciador neste exato momento
        if (PlayerObserverManager.Instancia != null)
        {
            AtualizarTextoMoedas(PlayerObserverManager.Instancia.QuantidadeMoedas);
            Debug.Log($"[UI] Conectado ao canal! Valor inicial recuperado: {PlayerObserverManager.Instancia.QuantidadeMoedas}");
        }
        else
        {
            Debug.LogWarning("[UI] PlayerObserverManager ainda não existe na cena.");
            textoMoedas.text = "Moedas: 0";
        }
    }

    private void OnDestroy()
    {
        // Sempre limpamos o evento quando o objeto deixa de existir para evitar bugs de memória
        PlayerObserverManager.OnMoedasAlteradas -= AtualizarTextoMoedas;
    }

    private void AtualizarTextoMoedas(int quantidade)
    {
        if (textoMoedas != null)
        {
            textoMoedas.text = "Moedas: " + quantidade.ToString();
            Debug.Log($"[UI VISUAL] O texto na tela mudou fisicamente para: Moedas: {quantidade}");
        }
        else
        {
            Debug.LogError("[UI] Erro Crítico: O campo 'textoMoedas' está vazio no Inspector!");
        }
    }
}