using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DefinitionBtn : MonoBehaviour
{
    [SerializeField]
    private TMP_Text titleText;
    [SerializeField] 
    private TMP_Text definitionTitle;
    [SerializeField] 
    private TMP_Text definitionText;

    public UnityEvent onSuccessClick;

    private Dictionary<String, String> _definitionsDict = new Dictionary<string, string>();
    
    // Start is called before the first frame update
    void Start()
    {
        _definitionsDict.Add("bienes raíces", "Son casas o departamentos que pones en renta a otros. Puede incluir casas " +
                                              "que son compradas entre varias personas y en las que la renta se reparte " +
                                              "(crowdfunding) ");
        _definitionsDict.Add("acciones", "Tener una acción significa que eres dueño de una partecita de una empresa. " +
                                         "Los dividendos son las ganancias de esa empresa que te entregan por ser uno de " +
                                         "sus dueños.");
        _definitionsDict.Add("fondos de inversión", "Los bancos u otras organizaciones financieras toman tu dinero y lo " +
                                                    "invierten para que gane intereses ");
        _definitionsDict.Add("franquicia", "Es un negocio en el que existe ya una marca y un modelo probado y tu tienes " +
                                           "el derecho de usarlo como si fuera tuyo, por ejemplo McDonalds o KFC");
    }

    public void ChangeDefinition()
    {
        if (_definitionsDict.TryGetValue(titleText.text.ToLower(), out var definition))
        {
            definitionTitle.text = titleText.text;
            definitionText.text = definition;
            onSuccessClick.Invoke();
        }
    }
}
