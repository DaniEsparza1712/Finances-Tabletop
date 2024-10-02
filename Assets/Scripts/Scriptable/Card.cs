using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Card")]
public class Card: ScriptableObject
{
    [Serializable]
    public class Option
    {
        [Header("Bills")]
        public int bills;
        public int feliciCoins;
        public int shareCoins;

        [Header("Tokens")] 
        public int activos;
        public int pasivos;
    }

    [Header("Card Info")] 
    public string title;
    [TextArea(4, 4)]
    public string description;


    [Header("Option 1")] 
    public Option option1;
    public string btn1Text = "OK";
    
    [Header("Option 2")]
    public bool secondOption;
    public string btn2Text = "Opción 2";

    public Option option2;

}
