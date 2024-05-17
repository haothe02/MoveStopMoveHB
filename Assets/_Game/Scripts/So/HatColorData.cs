using Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HatType
{
    Arrow = 0,
    Cap = 1,
    Cowboy = 2,
    Crown = 3,
    Ear = 4,
    HeadPhone = 5,
    Horn = 6,
    PoliceCap = 7,
    StrawHat = 9
}
[CreateAssetMenu(fileName = "HatColor", menuName = "ScriptableObjects/HatMatData")]
public class HatColorData : ScriptableObject
{
    //theo tha material theo dung thu tu ColorType
    public List<Material> _materials;
    public List<ItemBase> _hat = new List<ItemBase>();
    //lay material theo mau tuong ung
    public Material GetHatMat(HatType hatType)
    {
        return _materials[(int)hatType];
    }
}
