using UnityEngine;
using UnityEngine.SceneManagement; // Obrigatório para trocar de cenas

public class GerenciadorDeCenas : MonoBehaviour
{
    // O método precisa ser "public" para aparecer no inspetor do botão
    public void CarregarCena(string nomeDaCena)
    {
        // Carrega a cena com base no nome digitado
        SceneManager.LoadScene(nomeDaCena);
        
        Debug.Log("Carregando a cena: " + nomeDaCena);
    }
}