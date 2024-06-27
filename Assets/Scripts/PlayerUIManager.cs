using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform diceRect;
    [SerializeField] 
    private RectTransform blueRect;
    [SerializeField] 
    private RectTransform greenRect;
    [SerializeField] 
    private RectTransform redRect;
    [SerializeField] 
    private RectTransform yellowRect;

    [Header("Coins")]
    public TMP_Text billsText;
    public TMP_Text feliciCoinsText;
    public TMP_Text shareCoinsText;

    [Header("Tokens")]
    public TMP_Text incomeText;
    public TMP_Text obligationsText;

    public void ChangeDiceActive(bool active)
    {
        diceRect.gameObject.SetActive(active);
    }
    public void ChangeBlueActive(bool active)
    {
        blueRect.gameObject.SetActive(active);
    }
    public void ChangeGreenActive(bool active)
    {
        greenRect.gameObject.SetActive(active);
    }
    public void ChangeRedActive(bool active)
    {
        redRect.gameObject.SetActive(active);
    }

    public void ChangeYellowActive(bool active)
    {
        yellowRect.gameObject.SetActive(active);
    }
}
