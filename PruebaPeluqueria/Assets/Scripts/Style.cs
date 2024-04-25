using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StyleTypes
{
    FaceOval, FrontHair, LateralHair, BackHair, Eyes, Mouth, Nose
}



[CreateAssetMenu(menuName =("Style/Generic Style"))]
public class Style : ScriptableObject
{
    public int ID;
    public string Name;
    public StyleTypes Type;
    public Sprite Icon;
    public Color DefaultColor;
    public Color Color;
    
    public bool Recolorable;

    [TextArea] public string Info;

}
