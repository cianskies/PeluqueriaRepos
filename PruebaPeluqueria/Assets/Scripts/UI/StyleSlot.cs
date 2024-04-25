using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StyleSlot : MonoBehaviour
{
    public static event OnClickHandler OnClickStyle;
    public delegate void OnClickHandler(Style style);

    //updatear el resto de datos, nombre, desc etccc
    [SerializeField] private Style _style;
    [SerializeField] private Image _icon;
    public Style Style { get => _style; set => _style = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (_style != null)
        {
            _icon.sprite = Style.Icon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        //Debug.Log("Click efectuado");
        OnClickStyle(_style);
    }
}
