using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DreamBtn : MonoBehaviour
{
    private Dream _dream;
    private DreamManager _dreamManager;
    private Button _btn;
    private TMP_Text _tmpText;
    [SerializeField]
    private Image _icon;
    // Start is called before the first frame update
    void Awake()
    {
        _btn = GetComponent<Button>();
        _tmpText = GetComponentInChildren<TMP_Text>();
    }

    public void Initialize(Dream newDream, DreamManager newDreamManager)
    {
        _dream = newDream;
        _dreamManager = newDreamManager;
        _tmpText.text = $"{_dream.dreamName} - ${_dream.billCost}";
        _icon.sprite = _dream.icon;
        
        _btn.onClick.AddListener(delegate {_dreamManager.SetDream(_dream);});
    }
}
