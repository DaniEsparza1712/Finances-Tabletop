using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Dream")]
public class Dream : ScriptableObject
{
    public string dreamName;
    public Sprite icon;
    public int billCost;
    public int feliciCoins;
}
