using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DreamManager : MonoBehaviour
{
    [SerializeField]
    private List<Dream> dreams;
    [SerializeField] 
    private DreamBtn dreamBtn;
    [SerializeField] 
    private RectTransform dreamContainer;
    [SerializeField] 
    private RectTransform dreamScreen;
    [SerializeField] 
    private RectTransform gameScreen;
    [SerializeField] 
    private RectTransform selectScreen;
    public Dream currentDream;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var dream in dreams)
        {
            var currentDreamBtn = Instantiate(dreamBtn, dreamContainer);
            currentDreamBtn.Initialize(dream, this);
        }
    }

    public void SetDream(Dream newDream)
    {
        currentDream = newDream;
        dreamScreen.gameObject.SetActive(false);
        selectScreen.gameObject.SetActive(true);
        selectScreen.GetComponentInChildren<TMP_Text>().text =
            $"Gana {currentDream.feliciCoins} FeliciCoins al cumplir este sueño.";
    }

    public void StartGame()
    {
        selectScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(true);
    }
}
