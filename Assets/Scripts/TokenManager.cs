using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TokenManager : MonoBehaviour
{
    [SerializeField]
    private int _activosCounter;
    public int GetActivos => _activosCounter;
    [SerializeField]
    private int _pasivosCounter;
    public int GetPasivos => _pasivosCounter;

    public UnityEvent onAddActivos;
    public UnityEvent onAddPasivos;
    public UnityEvent onActivosGreaterThanPasivos;

    public void AddActivos(int activos)
    {
        _activosCounter += activos;
        onAddActivos.Invoke();
    }

    public void AddPasivos(int pasivos)
    {
        _pasivosCounter += pasivos;
        onAddPasivos.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
    }
}
