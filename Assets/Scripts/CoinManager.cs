using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    [SerializeField, Header("Bills")]
    private int startingBills;
    private int _bills;
    public int GetBills => _bills;
    public UnityEvent onAddBills;
    public UnityEvent onSpendBills;

    [SerializeField, Header("Felicicoins")]
    private int _feliciCoins;
    public int GetFelicicoins => _feliciCoins;
    public UnityEvent onAddFelicicoins;

    [SerializeField, Header("Sharecoins")]
    private int _sharecoins;
    public int GetSharecoins => _sharecoins;
    public UnityEvent onAddSharecoins;

    public bool CanAddBills(int billsToAdd)
    {
        if (_bills + billsToAdd >= 0)
        {
            return true;
        }
        return false;
    }
    public void AddBills(int billsToAdd)
    {
        _bills += billsToAdd;
        onAddBills.Invoke();
    }
    public bool CanAddFelicicoins(int felicicoinsToAdd)
    {
        if (_feliciCoins + felicicoinsToAdd >= 0)
        {
            return true;
        }
        return false;
    }
    public void AddFelicicoins(int felicicoinsToAdd)
    {
        _feliciCoins += felicicoinsToAdd;
        onAddFelicicoins.Invoke();
        
    }
    public bool CanAddSharecoins(int sharecoinsToAdd)
    {
        if (_sharecoins + sharecoinsToAdd >= 0)
        {
            return true;
        }
        return false;
    }
    public void AddSharecoins(int sharecoinsToAdd)
    {
        _sharecoins += sharecoinsToAdd;
        onAddSharecoins.Invoke();
    }
    // Start is called before the first frame update
    void Awake()
    {
        _bills = startingBills;
        _feliciCoins = 0;
        _sharecoins = 0;
    }
}
