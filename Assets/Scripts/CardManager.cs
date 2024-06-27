using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    [Header("Card info")]
    [SerializeField]
    private List<Card> cards;
    [SerializeField] 
    private TMP_Text title;
    [SerializeField] 
    private TMP_Text desc;
    [SerializeField] 
    private Button btn1;
    [SerializeField] 
    private Button btn2;
    [SerializeField]
    private PlayerManager playerManager;
    
    [Header("Summary Input")][SerializeField]
    private GameObject expenseInfoPrefab;
    [SerializeField]
    private Sprite feliciCoinSprite;
    [SerializeField]
    private Sprite billSprite;
    [SerializeField]
    private Sprite shareCoinSprite;
    [SerializeField]
    private Sprite passiveSprite;
    [SerializeField]
    private Sprite activeSprite;

    [Header("Summary: Option 1")] [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    private RectTransform content;

    [Header("Summary: Option 2")] [SerializeField]
    private RectTransform rectTransform2;
    [SerializeField]
    private RectTransform content2;

    [Header("Events")] 
    public UnityEvent successfulClick;
    public UnityEvent failedClick;

    public void FillOutCard(int index)
    {
        title.text = cards[index].title;
        desc.text = cards[index].description;
    }

    private void ClearChildren(Transform contentTransform)
    {
        foreach (Transform child in contentTransform)
        {
            Destroy(child.gameObject);
        }
    }

    private void FillOutSummary1(int index)
    {
        ClearChildren(content);
        if (Mathf.Abs(cards[index].option1.bills) > 0)
        {
            var billExpenses = Instantiate(expenseInfoPrefab, content);
            billExpenses.transform.GetChild(0).GetComponent<Image>().sprite = billSprite;
            billExpenses.transform.GetChild(1).GetComponent<TMP_Text>().text = cards[index].option1.bills.ToString();
        }
        if (Mathf.Abs(cards[index].option1.feliciCoins) > 0)
        {
            var feliciExpenses = Instantiate(expenseInfoPrefab, content);
            feliciExpenses.transform.GetChild(0).GetComponent<Image>().sprite = feliciCoinSprite;
            feliciExpenses.transform.GetChild(1).GetComponent<TMP_Text>().text = cards[index].option1.feliciCoins.ToString();
        }
        if (Mathf.Abs(cards[index].option1.shareCoins) > 0)
        {
            var shareExpenses = Instantiate(expenseInfoPrefab, content);
            shareExpenses.transform.GetChild(0).GetComponent<Image>().sprite = shareCoinSprite;
            shareExpenses.transform.GetChild(1).GetComponent<TMP_Text>().text = cards[index].option1.shareCoins.ToString();
        }
        if (Mathf.Abs(cards[index].option1.pasivos) > 0)
        {
            var passiveExpenses = Instantiate(expenseInfoPrefab, content);
            passiveExpenses.transform.GetChild(0).GetComponent<Image>().sprite = passiveSprite;
            passiveExpenses.transform.GetChild(1).GetComponent<TMP_Text>().text = cards[index].option1.pasivos.ToString();
        }
        if (Mathf.Abs(cards[index].option1.activos) > 0)
        {
            var activeExpenses = Instantiate(expenseInfoPrefab, content);
            activeExpenses.transform.GetChild(0).GetComponent<Image>().sprite = activeSprite;
            activeExpenses.transform.GetChild(1).GetComponent<TMP_Text>().text = cards[index].option1.activos.ToString();
        }
        rectTransform.gameObject.SetActive(true);
        btn1.gameObject.GetComponentInChildren<TMP_Text>().text = cards[index].btn1Text;
        btn1.onClick.RemoveAllListeners();
        btn1.onClick.AddListener(Call);

        void Call()
        {
            var bills = cards[index].option1.bills;
            var feliciCoins = cards[index].option1.feliciCoins;
            var shareCoins = cards[index].option1.shareCoins;

            var incomeTokens = cards[index].option1.activos;
            var obligationsTokens = cards[index].option1.pasivos;
            
            if (playerManager.CanAddCardOption(cards[index].option1))
            {
                playerManager.AddCoins(bills, feliciCoins, shareCoins);
                playerManager.AddTokens(incomeTokens, obligationsTokens);
                successfulClick.Invoke();
            }
            else
                failedClick.Invoke();
        }
    }
    
    private void FillOutSummary2(int index)
    {
        ClearChildren(content2);
        var appear = false;
        if (Mathf.Abs(cards[index].option2.bills) > 0)
        {
            var billExpenses = Instantiate(expenseInfoPrefab, content2);
            billExpenses.transform.GetChild(0).GetComponent<Image>().sprite = billSprite;
            billExpenses.transform.GetChild(1).GetComponent<TMP_Text>().text = cards[index].option2.bills.ToString();
            appear = true;
        }
        if (Mathf.Abs(cards[index].option2.feliciCoins) > 0)
        {
            var feliciExpenses = Instantiate(expenseInfoPrefab, content2);
            feliciExpenses.transform.GetChild(0).GetComponent<Image>().sprite = feliciCoinSprite;
            feliciExpenses.transform.GetChild(1).GetComponent<TMP_Text>().text = cards[index].option2.feliciCoins.ToString();
            appear = true;
        }
        if (Mathf.Abs(cards[index].option2.shareCoins) > 0)
        {
            var shareExpenses = Instantiate(expenseInfoPrefab, content2);
            shareExpenses.transform.GetChild(0).GetComponent<Image>().sprite = shareCoinSprite;
            shareExpenses.transform.GetChild(1).GetComponent<TMP_Text>().text = cards[index].option2.shareCoins.ToString();
            appear = true;
        }
        if (Mathf.Abs(cards[index].option2.pasivos) > 0)
        {
            var passiveExpenses = Instantiate(expenseInfoPrefab, content2);
            passiveExpenses.transform.GetChild(0).GetComponent<Image>().sprite = passiveSprite;
            passiveExpenses.transform.GetChild(1).GetComponent<TMP_Text>().text = cards[index].option2.pasivos.ToString();
            appear = true;
        }
        if (Mathf.Abs(cards[index].option2.activos) > 0)
        {
            var activeExpenses = Instantiate(expenseInfoPrefab, content2);
            activeExpenses.transform.GetChild(0).GetComponent<Image>().sprite = activeSprite;
            activeExpenses.transform.GetChild(1).GetComponent<TMP_Text>().text = cards[index].option2.activos.ToString();
            appear = true;
        }
        rectTransform2.gameObject.SetActive(appear);
        btn2.gameObject.SetActive(appear);
        btn2.gameObject.GetComponentInChildren<TMP_Text>().text = cards[index].btn2Text;
        btn2.onClick.RemoveAllListeners();
        btn2.onClick.AddListener(Call);

        void Call()
        {
            var bills = cards[index].option2.bills;
            var feliciCoins = cards[index].option2.feliciCoins;
            var shareCoins = cards[index].option2.shareCoins;

            var incomeTokens = cards[index].option2.activos;
            var obligationsTokens = cards[index].option2.pasivos;
            
            if (playerManager.CanAddCardOption(cards[index].option2))
            {
                playerManager.AddCoins(bills, feliciCoins, shareCoins);
                playerManager.AddTokens(incomeTokens, obligationsTokens);
                successfulClick.Invoke();
            }
            else
                failedClick.Invoke();
        }
    }

    private void OnEnable()
    {
        var randNum = Random.Range(0, cards.Count);
        FillOutCard(randNum);
        FillOutSummary1(randNum);
        FillOutSummary2(randNum);
    }
}
