using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BlueCardManager : MonoBehaviour
{
    [Header("Managers")] 
    public PlayerUIManager playerUIManager;
    public TokenManager tokenManager;
    public CoinManager coinManager;

    [Header("Summary")] 
    public GameObject expenseInfoPrefab;
    public Transform summaryContent;
    public RectTransform summaryRect;
    public Sprite billSprite;

    [Header("Button")] 
    public Button btn;
    public UnityEvent successfulClick;

    private void Start()
    {
        btn.onClick.AddListener(successfulClick.Invoke);
    }

    private void OnEnable()
    {
        summaryRect.gameObject.SetActive(true);
        FillSummary();
    }

    private int GetBillsToAdd()
    {
        var passive = tokenManager.GetActivos;
        var obligations = tokenManager.GetPasivos;

        return 1000 + (passive * 100) - (obligations * 100);
    }

    public void AddBills()
    {
        coinManager.AddBills(GetBillsToAdd());
        playerUIManager.billsText.text = $"${coinManager.GetBills}";
    }
    
    private void FillSummary()
    {
        ClearChildren(summaryContent);
        var billsInfo = Instantiate(expenseInfoPrefab, summaryContent);
        billsInfo.transform.GetChild(0).GetComponent<Image>().sprite = billSprite;
        billsInfo.transform.GetChild(1).GetComponent<TMP_Text>().text = GetBillsToAdd().ToString();
    }
    
    private void ClearChildren(Transform contentTransform)
    {
        foreach (Transform child in contentTransform)
        {
            Destroy(child.gameObject);
        }
    }
}
