using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{

    [Header("Style selector ui")]
    [SerializeField] private StyleSlot _styleSlotPrefab;
    [SerializeField] private Transform _stylePanel;
    private Style _selectedStyle;
    private ResizableStyle _selectedResizableStyle;
    private string _selectedStyleName;

    [SerializeField] private List<StyleSlot> _aviableSlots;

    [SerializeField]private ResizeManager _resizeManager;


    [Header("Model ui")]
    [SerializeField] private Image _ovalImg;
    [SerializeField] private Image _frontHairImg;
    [SerializeField] private Image _sideHairImg;



    [SerializeField] private Image _eyesImg;
    [SerializeField] private Image _nosesImg;
    [SerializeField] private Image _mouthImg;



    public string SelectedStyleName { get => _selectedStyleName; set => _selectedStyleName = value; }
    public Style SelectedStyle { get => _selectedStyle; set => _selectedStyle = value; }
    public ResizableStyle SelectedResizableStyle { get => _selectedResizableStyle; set => _selectedResizableStyle = value; }



    // Start is called before the first frame update
    void Start()
    {
        _resizeManager=GetComponent<ResizeManager>();
        _selectedStyleName = "Oval";
        UpdateToSelectedStyle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectStyle(string styleName)
    {

        _selectedStyleName= styleName;
        ClearStyleList();
        UpdateToSelectedStyle();
    }
    private void ClearStyleList()
    {
        while(_aviableSlots.Count > 0)
        {
            Destroy(_aviableSlots[0].gameObject);
            _aviableSlots.RemoveAt(0);
        }
    }
    private void UpdateToSelectedStyle()
    {
        
        _aviableSlots.Clear();
        InventoryStyleFamily selectedFamily= StyleHandler.Instance.GetStyleFamilyByName(_selectedStyleName);
        Style[] selectedStyles=selectedFamily.Styles;
        for (int i = 0; i < selectedStyles.Length; i++)
        {
            StyleSlot slot = Instantiate(_styleSlotPrefab, _stylePanel);
            
            slot.Style= selectedStyles[i];
            //updatear el resto de datos, nombre, desc etccc
            _aviableSlots.Add(slot);
        }
    }
    public void StyleChangedUpdate(Style style)
    {
        if(style is ResizableStyle)
        {
            _selectedResizableStyle=(ResizableStyle)style;
            _resizeManager.ResizableStyleChangedUpdate((ResizableStyle)style);
        }
        else
        {
            //Debug.Log(style.Name);
            switch (style.Type)
            {

                case (StyleTypes.FaceOval):
                    _ovalImg.sprite = style.Icon;
                    break;
                case (StyleTypes.FrontHair):
                    _frontHairImg.sprite = style.Icon;
                    _frontHairImg.color = style.Color;
                    break;

            }
            _selectedResizableStyle=null;
        }
        _selectedStyle = style;
        _resizeManager.EnableDisableResizePanel();

    }


    private void OnEnable()
    {
        StyleSlot.OnClickStyle += StyleChangedUpdate;
    }
    private void OnDisable()
    {
        StyleSlot.OnClickStyle -= StyleChangedUpdate;
    }

}
