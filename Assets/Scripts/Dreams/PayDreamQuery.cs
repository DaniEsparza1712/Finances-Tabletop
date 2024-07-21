using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PayDreamQuery : MonoBehaviour
{
    public DreamManager dreamManager;
    public CoinManager coinManager;
    public TokenManager tokenManager;
    public PlayerManager playerManager;
    
    public UnityEvent onSuccess;
    public UnityEvent onFail;

    public TMP_Text description;
    public Button confirmBtn;

    private void OnEnable()
    {
        if (tokenManager.GetActivos > tokenManager.GetPasivos)
        {
            var dream = dreamManager.currentDream;
            description.text = $"Cumple tu sueño: {dream.dreamName}. Paga ${dream.billCost} para ganar {dream.feliciCoins} " +
                               $"FeliciCoins y terminar el juego";
            confirmBtn.gameObject.SetActive(true);
        }
        else
        {
            description.text = "Asegúrate de que tus ingresos pasivos superen tus obligaciones para pagar tu sueño.";
            confirmBtn.gameObject.SetActive(false);
        }
    }

    public void ClickConfirm()
    {
        Debug.Log("Clicked");
        if (coinManager.GetBills >= dreamManager.currentDream.billCost)
        {
            coinManager.AddFelicicoins(dreamManager.currentDream.feliciCoins);
            coinManager.AddBills(-dreamManager.currentDream.billCost);
            playerManager.UpdateCoinsUI();
            playerManager.UpdateTokensUI();
            
            onSuccess.Invoke();
            Debug.Log("Success");
        }
        else
        {
            
            onFail.Invoke();
            Debug.Log("Failed");
        }
    }
}
