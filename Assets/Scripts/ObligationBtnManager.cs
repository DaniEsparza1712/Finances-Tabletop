using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObligationBtnManager : MonoBehaviour
{
    public UnityEvent failedClick;
    public UnityEvent successClick;
    public CoinManager coinManager;
    public TokenManager tokenManager;

    public void ValidateClick()
    {
        if (coinManager.GetBills >= 1000 && tokenManager.GetPasivos > 0)
        {
            successClick.Invoke();
        }
        else
        {
            failedClick.Invoke();
        }
    }
}
