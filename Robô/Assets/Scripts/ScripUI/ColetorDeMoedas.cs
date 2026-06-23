using UnityEngine;

public class ColetorDeMoedas : MonoBehaviour
{
    private void OnTriggerEnter(Collider outro)
    {
        // RASTREADOR 1: O Unity detectou QUALQUER colisão?
        Debug.Log($"[FÍSICA] Encostei em algo chamado: {outro.name} | Tag real do objeto: '{outro.tag}'");

        if (outro.CompareTag("moeda"))
        {
            // RASTREADOR 2: A tag funcionou?
            Debug.Log("<color=cyan>[COLETA] Tag 'moeda' confirmada! Tentando avisar o Gerenciador...</color>");

            if (PlayerObserverManager.Instancia != null)
            {
                PlayerObserverManager.Instancia.AdicionarMoeda();
            }
            else
            {
                // RASTREADOR 3: Erro de script faltando
                Debug.LogError("[ERRO] O PlayerObserverManager não foi encontrado na cena!");
            }

            Destroy(outro.gameObject);
        }
    }
}