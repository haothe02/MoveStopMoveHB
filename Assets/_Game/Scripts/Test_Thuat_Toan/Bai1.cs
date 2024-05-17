using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai1 : MonoBehaviour
{
    void Start()
    {
        int minOdd = int.MaxValue;
        int maxEven = int.MinValue;

        int[] arr = new int[] { 1, 5, 3, 7, 6, 8, 4, 8, 1, 0 };
        
        foreach (int num in arr)
        {
            if (num % 2 != 0 && num < minOdd)
            {
                minOdd = num;
            }
            else if (num % 2 == 0 && num > maxEven)
            {
                maxEven = num;
            }
        }

        Debug.Log("min: " + minOdd + " - max: " + maxEven);
    }
}
