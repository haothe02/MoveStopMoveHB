using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai4 : MonoBehaviour
{
    private static bool DiemTrenDuong(Vector2 point, Vector2 a, Vector2 b)
    {
        Vector2 vecap = point - a;
        Vector2 vecab = b - a;

        // tích vô hướng của 2 vector
        float crossProduct = Vector3.Cross(vecap, vecab).z;

        // Nếu tích vô hướng của 2 vector gần bằng 0 thì là cùng hướng, ngược lại thì không
        return Mathf.Approximately(crossProduct, 0f);
    }

    void Start()
    {
        Vector2 point1 = new Vector2(1, 1);
        Vector2 a1 = new Vector2(0, 2);
        Vector2 b1 = new Vector2(2, 0);
        Debug.Log("DiemTrenDuong(point1, a1, b1): " + DiemTrenDuong(point1, a1, b1)); 

        Vector2 point2 = new Vector2(0, 0);
        Vector2 a2 = new Vector2(0, 2);
        Vector2 b2 = new Vector2(2, 0);
        Debug.Log("DiemTrenDuong(point2, a2, b2): " + DiemTrenDuong(point2, a2, b2)); 
    }
}
