using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public static class Cache 
{
    private static Dictionary<Collider, CharacterManagement> _characters = new Dictionary<Collider, CharacterManagement>();

    public static CharacterManagement GetCharacter(Collider _collider)
    {
        if (!_characters.ContainsKey(_collider))
        {
            _characters.Add(_collider, _collider.GetComponent<CharacterManagement>());
        }
        return _characters[_collider];
    }

}
