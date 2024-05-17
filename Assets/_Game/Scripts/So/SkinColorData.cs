using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SkinType
{
    Batman = 0,
    Chambi = 1,
    Comi = 2,
    Onion = 3,
    Rainbow = 4,
    None = 5
}
[CreateAssetMenu(fileName = "SkinColor", menuName = "ScriptableObjects/SkinData")]
public class SkinColorData : ScriptableObject
{
    //theo tha material theo dung thu tu ColorType
    public List<Material> _materials;
    public List<ItemBase> _skin = new List<ItemBase>();
    //lay material theo mau tuong ung
    public Material GetSkinMat(SkinType skinType)
    {
        return _materials[(int)skinType];
    }
}
