using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    [Header("Recolor")]
    [SerializeField] private GameObject _recolorPanel;
    [SerializeField] private Scrollbar _recolorbar;



    public void OnValueChangedRecolorBar()
    {
        float normalizedvalue = _recolorbar.value;
        Color newColor = Color.HSVToRGB(normalizedvalue, 1f, 1f);
        ResizableStyle rStyle = UIManager.Instance.SelectedResizableStyle;
        Style style=UIManager.Instance.SelectedStyle;

            style.Color = newColor;
            UIManager.Instance. StyleChangedUpdate(style);
        

    }
}