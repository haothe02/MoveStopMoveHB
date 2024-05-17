using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai2 : MonoBehaviour
{
    void Start()
    {
        List<int> list = new List<int> { 1, 2, 3, 4, 5, 4, 4, 6, 8, 9, 10 };

        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] == 4)
            {
                list.RemoveAt(i);
            }
        }

        Debug.Log("Danh sach sau khi xoa 4: ");
        foreach (int num in list)
        {
            Debug.Log(num);
        }
    }
}
