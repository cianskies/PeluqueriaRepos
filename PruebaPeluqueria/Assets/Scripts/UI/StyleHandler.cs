using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StyleHandler : Singleton<StyleHandler>
{
    [SerializeField] private InventoryStyleFamily[] _styleFamilies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public InventoryStyleFamily GetStyleFamilyByName(string name)
    {
        InventoryStyleFamily family=null;
        bool found=false;
        for (int i = 0; i < _styleFamilies.Length&& !found; i++)
        {
            if (_styleFamilies[i].Name.Equals(name))
            {
                family= _styleFamilies[i]; 
            }
        }
        return family;
    }
}
[Serializable]
public class InventoryStyleFamily
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [TextArea] private string _info;
    [SerializeField] private Style[] _styles;

    public string Name { get => _name; set => _name = value; }
    public Sprite Icon { get => _icon; set => _icon = value; }
    public string Info { get => _info; set => _info = value; }
    public Style[] Styles { get => _styles; set => _styles = value; }
}

