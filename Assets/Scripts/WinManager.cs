using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public CoinManager coinManager;
    public TMP_Text text;

    private void OnEnable()
    {
        text.text = $"¡Cumpliste tu sueño! Terminaste la partida con {coinManager.GetFelicicoins} FeliciCoins";
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
