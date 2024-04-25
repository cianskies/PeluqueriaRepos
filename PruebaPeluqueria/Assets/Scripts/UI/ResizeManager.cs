using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeManager : MonoBehaviour
{
    [Header("Resize")]
    [SerializeField] private GameObject _resizePanel;
    [SerializeField] private Scrollbar _resizebar;

    [Header("Resizable UI components")]
    [Header("Back Hair")]
    [SerializeField] private Image _beginingBackHairImg;
    [SerializeField] private Image _resizableBackHairImg;
    [SerializeField] private Image _endingBackHairImg;

    private readonly float MIN_RESIZE_VALUE = 1;
    private readonly float MAX_RESIZE_VALUE = 10;
    public void EnableDisableResizePanel()
    {
        ResizableStyle style = UIManager.Instance.SelectedResizableStyle;
        _resizePanel.SetActive( style!= null);
        if (style != null)
        {
            OnValueChangedResizeBar();
        }
    }


    public void ResizableStyleChangedUpdate(ResizableStyle style)
    {
        switch (style.Type)
        {
            case (StyleTypes.BackHair):
                _beginingBackHairImg.sprite=style.Begining;
                _resizableBackHairImg.sprite = style.ResizableArea;
                _endingBackHairImg.sprite=style.Ending;

                _beginingBackHairImg.color=style.Color;
                _resizableBackHairImg.color=style.Color;
                _endingBackHairImg.color=style.Color;

                break;
        }
    }

    public void OnValueChangedResizeBar()
    {
        //Debug.Log(_resizebar.value);
        ResizableStyle style = UIManager.Instance.SelectedResizableStyle;
        switch (style.Type)
        {

            case (StyleTypes.BackHair):

                float normalizedvalue = _resizebar.value;
                float resizeValue = Mathf.Lerp(MIN_RESIZE_VALUE, MAX_RESIZE_VALUE, normalizedvalue);
                //Cambia la escala Y de la parte escalable del pelo
                _resizableBackHairImg.gameObject.transform.localScale = new Vector3(1f,
                     resizeValue, 0);
                //La parte final del pelo cambia su escala a la inversa qye su objeto padre para evitar que se deforme
                _endingBackHairImg.gameObject.transform.localScale =
                    new Vector3(1f,
                    1f / _resizableBackHairImg.gameObject.transform.localScale.y,
                    0);
                break;
        }

    }


}
