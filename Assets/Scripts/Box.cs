using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public enum BoxType
    {
        Red,
        Green,
        Yellow,
        Blue
    }
    [SerializeField] private BoxType type;
    public BoxType GetBoxType => type;
}
