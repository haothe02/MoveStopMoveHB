using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scriptable
{
    public enum PantType
    {
        Batman = 0,
        Chambi = 1,
        Comi = 2,
        Onion = 3,
        Rainbow = 4,
        None = 5
    }

    [CreateAssetMenu(fileName = "PantColor", menuName = "ScriptableObjects/PantMatData")]
    public class PantColorData : ScriptableObject
    {
        //theo tha material theo dung thu tu ColorType
        public List<Material> _materials;
        public List<ItemBase> _pant = new List<ItemBase>();
        //lay material theo mau tuong ung
        public Material GetPantMat(PantType pantType)
        {
            return _materials[(int)pantType];
        }
    }
}
